using ERP.Core.enums;

namespace ERP.Core.EntityParams.purchaseOrderParams
{
    public record AddPurchaseOrderParams
    {
        public int SupplierId { get; set; }
        public enStatus OrderStatus { get; set; } = enStatus.Pending;
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
