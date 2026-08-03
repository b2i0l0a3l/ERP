using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Requests.Commands
{
    public record CreateInvoiceItemCommand : IRequest<Result<int>>
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal LineTotal { get; set; }
    }
}
