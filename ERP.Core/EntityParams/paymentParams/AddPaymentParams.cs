using ERP.Core.enums;

namespace ERP.Core.EntityParams.paymentParams
{
    public record AddPaymentParams
    {
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; }
        public enPaymentMethod PaymentMethod { get; set; } = enPaymentMethod.Cash;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
