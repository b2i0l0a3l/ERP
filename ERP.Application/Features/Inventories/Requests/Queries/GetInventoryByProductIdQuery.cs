using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Queries
{
    public record GetInventoryByProductIdQuery : IRequest<Result<InventoryDTO>>
    {
        public int ProductId { get; set; }
    }
}
