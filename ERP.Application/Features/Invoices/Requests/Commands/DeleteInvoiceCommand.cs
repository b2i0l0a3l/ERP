using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Commands
{
    public record DeleteInvoiceCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
