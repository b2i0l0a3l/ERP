using ERP.Application.Features.Products.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Queries
{
    public class GetProductByBarcodeQueryHandler : IRequestHandler<GetProductByBarcodeQuery, Result<ProductDTO>>
    {
        private readonly IProductRepo _repo;
        public GetProductByBarcodeQueryHandler(IProductRepo repo) => _repo = repo;
        public async ValueTask<Result<ProductDTO>> Handle(GetProductByBarcodeQuery request, CancellationToken ct)
            => await _repo.GetByBarcode(request.Barcode);
    }
}
