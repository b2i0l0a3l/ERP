using ERP.Application.Features.Products.Requests.Queries;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Queries
{
    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, Result<PagedResult<ProductDTO>>>
    {
        private readonly IProductRepo _repo;
        public GetProductsPagedQueryHandler(IProductRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<ProductDTO>>> Handle(GetProductsPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, ProductName = request.ProductName, BarCode = request.BarCode });
    }
}
