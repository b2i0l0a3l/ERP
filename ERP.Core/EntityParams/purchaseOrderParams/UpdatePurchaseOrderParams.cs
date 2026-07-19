using ERP.Core.enums;

namespace ERP.Core.EntityParams.purchaseOrderParams
{
    public class UpdatePurchaseOrderParams
    {
        public enStatus OrderStatus { get; set; } = enStatus.Pending;
        public decimal Total { get; set; }
    }
}
