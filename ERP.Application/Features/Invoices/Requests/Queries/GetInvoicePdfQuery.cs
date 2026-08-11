using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Queries
{
    public record GetInvoicePdfQuery : IRequest<Result<InvoicePdfResponseDto>>
    {
        public int Id { get; set; }
    }
}
