using ERP.Application.Features.Suppliers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Queries
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Result<SupplierDTO>>
    {
        private readonly ISupplierRepo _repo;
        public GetSupplierByIdQueryHandler(ISupplierRepo repo) => _repo = repo;
        public async ValueTask<Result<SupplierDTO>> Handle(GetSupplierByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
