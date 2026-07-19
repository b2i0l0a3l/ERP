using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record BuyCommand : IRequest<Result<int>>
    {
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
        public string CreatedByUserId { get; set; } = string.Empty;
        public List<BuyItems> Items { get; set; } = new();
    }
}
