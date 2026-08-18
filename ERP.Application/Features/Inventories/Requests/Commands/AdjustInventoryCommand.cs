using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record AdjustInventoryCommand : IRequest<Result<bool>>
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int NewQuantity { get; set; }
        public string AdjustedByUserId { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
