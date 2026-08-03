using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<bool>>
    {
        private readonly IProductRepo _repo;
        public UpdateProductCommandHandler(IProductRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateProductCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateProductParams
            {
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                Barcode = request.Barcode,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                CostPrice = request.CostPrice,
                SellingPrice = request.SellingPrice
            });
    }
}
