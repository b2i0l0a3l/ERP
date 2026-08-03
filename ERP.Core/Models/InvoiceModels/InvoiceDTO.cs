using ERP.Core.enums;

namespace ERP.Core.Models.InvoiceModels
{
    public record InvoiceDTO
    {
        public int Id { get; init; }
        public string? InvoiceNumber { get; set; }
        public enInvoiceType Type { get; set; }
        public enInvoiceStatus Status { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
