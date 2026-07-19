using ERP.Application.Features.Suppliers.Requests.Commands;
using ERP.Core.EntityParams.supplierParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Commands
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result<int>>
    {
        private readonly ISupplierRepo _repo;
        public CreateSupplierCommandHandler(ISupplierRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreateSupplierCommand request, CancellationToken ct)
            => await _repo.Add(new AddSupplierParams { FirstName = request.FirstName, LastName = request.LastName, FullName = $"{request.FirstName} {request.LastName}" });
    }
}
