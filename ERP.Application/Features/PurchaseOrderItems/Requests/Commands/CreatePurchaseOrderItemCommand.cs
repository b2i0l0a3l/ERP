using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Commands
{
    public record CreatePurchaseOrderItemCommand : IRequest<Result<int>>
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
