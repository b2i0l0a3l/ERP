using ERP.Application.Features.Inventories.Requests.Queries;
using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Queries
{
    public class GetInventoryByWarehouseQueryHandler : IRequestHandler<GetInventoryByWarehouseQuery, Result<PagedResult<InventoryDTO>>>
    {
        private readonly IInventoryRepo _repo;
        public GetInventoryByWarehouseQueryHandler(IInventoryRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<InventoryDTO>>> Handle(GetInventoryByWarehouseQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, WarehouseId = request.WarehouseId });
    }
}
