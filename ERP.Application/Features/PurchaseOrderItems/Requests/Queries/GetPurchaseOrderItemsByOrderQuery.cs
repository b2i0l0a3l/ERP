using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Queries
{
    public record GetPurchaseOrderItemsByOrderQuery : IRequest<Result<List<PurchaseOrderItemDTO>>>
    {
        public int PurchaseOrderId { get; set; }
    }
}
