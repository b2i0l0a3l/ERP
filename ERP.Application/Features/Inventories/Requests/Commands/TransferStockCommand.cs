using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record TransferStockCommand : IRequest<Result<bool>>
    {
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string AdjustedByUserId { get; set; } = string.Empty;
        public string? Reason { get; set; }
    }
}
