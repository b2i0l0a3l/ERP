using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Queries
{
    public record GetPurchaseOrderItemsByOrderQuery : IRequest<Result<PagedResult<PurchaseOrderItemDTO>>>
    {
        public int PurchaseOrderId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
