using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Queries
{
    public record GetInventoryByWarehouseQuery : IRequest<Result<PagedResult<InventoryDTO>>>
    {
        public int WarehouseId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
