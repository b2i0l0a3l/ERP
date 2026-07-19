using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepo _repo;
        public CreateProductCommandHandler(IProductRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken ct)
        {
            return await _repo.Add(new AddProductParams
            {
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                Barcode = request.Barcode,
                CostPrice = request.CostPrice,
                SellingPrice = request.SellingPrice,
                ImageUrl = request.ImageUrl,
                CreatedByUserId = request.CreatedByUserId
            });
        }
    }
}
