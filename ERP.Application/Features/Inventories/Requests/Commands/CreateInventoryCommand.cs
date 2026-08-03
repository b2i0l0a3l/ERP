using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record CreateInventoryCommand : IRequest<Result<int>>
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
