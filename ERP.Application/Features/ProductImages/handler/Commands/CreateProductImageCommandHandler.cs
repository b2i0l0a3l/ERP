using ERP.Application.Features.ProductImages.Requests.Commands;
using ERP.Core.EntityParams.productImageParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.ProductImages.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, Result<int>>
    {
        private readonly IProductImageRepo _repo;
        private readonly IFileStorageService _file;

        public CreateProductImageCommandHandler(IProductImageRepo repo, IFileStorageService file)
        {
            _repo = repo;
            _file = file;
        }

        public async ValueTask<Result<int>> Handle(CreateProductImageCommand request, CancellationToken ct)
        {
            var imageUrl = request.ImageUrl ?? string.Empty;

            if (request.Image != null && request.Image.Length > 0)
            {
                using var stream = request.Image.OpenReadStream();
                imageUrl = await _file.SaveFileAsync(stream, request.Image.FileName, "products");
            }

            return await _repo.Add(new AddProductImageParams { ProductId = request.ProductId, ImageUrl = imageUrl });
        }
    }
}
