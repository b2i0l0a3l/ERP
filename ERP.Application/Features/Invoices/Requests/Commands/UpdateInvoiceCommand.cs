using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Commands
{
    public record UpdateInvoiceCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
    }
}
