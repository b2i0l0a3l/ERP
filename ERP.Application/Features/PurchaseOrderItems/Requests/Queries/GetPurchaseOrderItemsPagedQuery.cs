using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Queries
{
    public record GetPurchaseOrderItemsPagedQuery : IRequest<Result<PagedResult<PurchaseOrderItemDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? PurchaseOrderId { get; set; }
    }
}
