using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Queries
{
    public record SearchProductsQuery : IRequest<Result<PagedResult<ProductDTO>>>
    {
        public string Query { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
