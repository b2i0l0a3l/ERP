using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Queries
{
    public record GetInventoryByIdQuery : IRequest<Result<InventoryDTO>>
    {
        public int Id { get; set; }
    }
}
