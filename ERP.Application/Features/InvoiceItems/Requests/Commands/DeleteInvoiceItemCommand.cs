using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Requests.Commands
{
    public record DeleteInvoiceItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
