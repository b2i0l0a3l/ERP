using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;
using Microsoft.AspNetCore.Http;

namespace ERP.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepo _repo;
        private readonly IRemoveFile _remove;
        private readonly IFileStorageService _file;
        public CreateProductCommandHandler(IRemoveFile remove,IProductRepo repo, IFileStorageService file)
        {
            _repo = repo;
            _file = file;
            _remove = remove;
        }
        public async ValueTask<Result<int>> Handle(CreateProductCommand request, CancellationToken ct)
        {
            List<string> imageUrls = new();
            if (request.Images != null && request.Images.Count > 0)
                imageUrls = await UploadProductImage(request.Images);

            var result = await _repo.Add(new AddProductParams
            {
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                Barcode = request.Barcode,
                CostPrice = request.CostPrice,
                SellingPrice = request.SellingPrice,
                ImageUrl = imageUrls.Any() ? imageUrls : null,
                CreatedByUserId = request.CreatedByUserId
            });

            if (result.IsSuccess == false)
            {
                RemoveProductImage(imageUrls);
            }
            return result;
        }
        private  void RemoveProductImage(List<string> Images)
        {
            if (Images != null)
            {
                foreach (string file in Images)
                {
                    _remove.remove(file);
                }
            }
        }
        private async Task<List<string>> UploadProductImage(List<IFormFile> Images)
        {
            List<string> imageUrls = new List<string>();
            if (Images != null)
            {
                foreach (var file in Images)
                {
                    if (file.Length > 0)
                    {
                        using var stream = file.OpenReadStream();
                        var relativePath = await _file.SaveFileAsync(stream, file.FileName, "products");
                        imageUrls.Add(relativePath);
                    }
                }
            }
            return imageUrls;
        }
    }
}
