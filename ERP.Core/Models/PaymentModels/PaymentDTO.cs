using ERP.Core.enums;

namespace ERP.Core.Models.PaymentModels
{
    public record PaymentDTO
    {
        public int Id { get; init; }
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; }
        public enPaymentMethod PaymentMethod { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
