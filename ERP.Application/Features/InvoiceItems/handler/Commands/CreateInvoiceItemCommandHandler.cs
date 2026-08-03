using ERP.Application.Features.InvoiceItems.Requests.Commands;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.handler.Commands
{
    public class CreateInvoiceItemCommandHandler : IRequestHandler<CreateInvoiceItemCommand, Result<int>>
    {
        public ValueTask<Result<int>> Handle(CreateInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            return new ValueTask<Result<int>>(new Error("NotImplemented", ErrorType.General, "Not implemented."));
        }
    }
}
