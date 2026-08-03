using ERP.Core.enums;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Commands
{
    public record CreateInvoiceCommand : IRequest<Result<int>>
    {
        public string? InvoiceNumber { get; set; }
        public enInvoiceType Type { get; set; }
        public enInvoiceStatus Status { get; set; } = enInvoiceStatus.Draft;
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
        public string? CreatedByUserId { get; set; }
    }
}
