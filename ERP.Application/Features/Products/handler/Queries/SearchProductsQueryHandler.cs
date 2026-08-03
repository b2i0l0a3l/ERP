using ERP.Application.Features.Products.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Queries
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, Result<PagedResult<ProductDTO>>>
    {
        private readonly IProductRepo _repo;
        public SearchProductsQueryHandler(IProductRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<ProductDTO>>> Handle(SearchProductsQuery request, CancellationToken ct)
            => await _repo.Search(request.Query, request.PageNumber, request.PageSize);
    }
}
