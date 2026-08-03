using ERP.Application.Features.Suppliers.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Commands
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Result<bool>>
    {
        private readonly ISupplierRepo _repo;
        public DeleteSupplierCommandHandler(ISupplierRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteSupplierCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
