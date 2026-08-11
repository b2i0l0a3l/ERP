using ERP.Core.enums;

namespace ERP.Core.Models.PurchaseOrderModels
{
    public record PurchaseOrderDTO
    {
        public int Id { get; init; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public enStatus OrderStatus { get; set; }
        public enPaymentStatus PaymentStatus { get; set; }
        public decimal Total { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
