using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Requests.Queries
{
    public record GetInvoiceItemsByInvoiceIdQuery : IRequest<Result<List<InvoiceItemDTO>>>
    {
        public int InvoiceId { get; set; }
    }
}
