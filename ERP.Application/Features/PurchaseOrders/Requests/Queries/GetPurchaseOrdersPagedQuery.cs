using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Requests.Queries
{
    public record GetPurchaseOrdersPagedQuery : IRequest<Result<PagedResult<PurchaseOrderDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? SupplierId { get; set; }
    }
}
