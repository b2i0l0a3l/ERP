using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Commands
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Result<bool>>
    {
        private readonly IInvoiceRepo _repo;
        public DeleteInvoiceCommandHandler(IInvoiceRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteInvoiceCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
