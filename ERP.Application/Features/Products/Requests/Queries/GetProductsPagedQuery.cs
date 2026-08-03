using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Requests.Queries
{
    public record GetProductsPagedQuery : IRequest<Result<PagedResult<ProductDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? ProductName { get; set; }
        public string? BarCode { get; set; }
    }
}
