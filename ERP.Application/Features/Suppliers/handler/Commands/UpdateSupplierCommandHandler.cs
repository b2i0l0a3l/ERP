using ERP.Application.Features.Suppliers.Requests.Commands;
using ERP.Core.EntityParams.supplierParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Commands
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result<bool>>
    {
        private readonly ISupplierRepo _repo;
        public UpdateSupplierCommandHandler(ISupplierRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateSupplierCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateSupplierParams { FirstName = request.FirstName, LastName = request.LastName, FullName = $"{request.FirstName} {request.LastName}" });
    }
}
