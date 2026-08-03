using ERP.Application.Features.InvoiceItems.Requests.Commands;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.handler.Commands
{
    public class UpdateInvoiceItemCommandHandler : IRequestHandler<UpdateInvoiceItemCommand, Result<bool>>
    {
        public ValueTask<Result<bool>> Handle(UpdateInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            return new ValueTask<Result<bool>>(new Error("NotImplemented", ErrorType.General, "Not implemented."));
        }
    }
}
