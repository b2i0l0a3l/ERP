using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record DeletePurchaseOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get => PurchaseOrderId; set => PurchaseOrderId = value; }
        public int PurchaseOrderId { get; set; }
        public int WarehouseId { get; set; }
        public string DeletedByUserId { get; set; } = string.Empty;
    }
}
