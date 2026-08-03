using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Requests.Queries
{
    public record GetInvoicePdfQuery : IRequest<Result<byte[]>>
    {
        public int Id { get; set; }
    }
}
