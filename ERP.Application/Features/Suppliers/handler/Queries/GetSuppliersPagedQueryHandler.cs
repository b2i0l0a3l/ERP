using ERP.Application.Features.Suppliers.Requests.Queries;
using ERP.Core.EntityParams.supplierParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Queries
{
    public class GetSuppliersPagedQueryHandler : IRequestHandler<GetSuppliersPagedQuery, Result<PagedResult<SupplierDTO>>>
    {
        private readonly ISupplierRepo _repo;
        public GetSuppliersPagedQueryHandler(ISupplierRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<SupplierDTO>>> Handle(GetSuppliersPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
