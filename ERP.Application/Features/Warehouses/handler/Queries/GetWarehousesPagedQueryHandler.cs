using ERP.Application.Features.Warehouses.Requests.Queries;
using ERP.Core.EntityParams.warehouseParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Queries
{
    public class GetWarehousesPagedQueryHandler : IRequestHandler<GetWarehousesPagedQuery, Result<PagedResult<WarehouseDTO>>>
    {
        private readonly IWarehouseRepo _repo;
        public GetWarehousesPagedQueryHandler(IWarehouseRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<WarehouseDTO>>> Handle(GetWarehousesPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
