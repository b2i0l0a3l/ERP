using ERP.Application.Features.InvoiceItems.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.InvoiceItems.Commands
{
    public class DeleteInvoiceItemCommandHandler : IRequestHandler<DeleteInvoiceItemCommand, Result<bool>>
    {
        private readonly IInvoiceItemRepo _repo;
        public DeleteInvoiceItemCommandHandler(IInvoiceItemRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteInvoiceItemCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
