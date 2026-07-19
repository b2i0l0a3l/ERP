using ERP.Application.Features.Inventories.Requests.Queries;
using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Queries
{
    public class GetInventoriesPagedQueryHandler : IRequestHandler<GetInventoriesPagedQuery, Result<PagedResult<InventoryDTO>>>
    {
        private readonly IInventoryRepo _repo;
        public GetInventoriesPagedQueryHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<InventoryDTO>>> Handle(GetInventoriesPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, WarehouseId = request.WarehouseId, ProductId = request.ProductId });
    }
}
