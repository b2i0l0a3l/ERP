using ERP.Application.Features.Suppliers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Queries
{
    public class GetSupplierByNameQueryHandler : IRequestHandler<GetSupplierByNameQuery, Result<SupplierDTO>>
    {
        private readonly ISupplierRepo _repo;
        public GetSupplierByNameQueryHandler(ISupplierRepo repo) => _repo = repo;
        public async ValueTask<Result<SupplierDTO>> Handle(GetSupplierByNameQuery request, CancellationToken ct)
            => await _repo.GetByName(request.Name);
    }
}
