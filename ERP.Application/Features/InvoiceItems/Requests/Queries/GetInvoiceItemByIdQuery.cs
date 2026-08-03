using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Requests.Queries
{
    public record GetInvoiceItemByIdQuery : IRequest<Result<InvoiceItemDTO>>
    {
        public int Id { get; set; }
    }
}
