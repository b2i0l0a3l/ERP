using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Requests.Commands
{
    public record CancelSalesOrderCommand : IRequest<Result<bool>>
    {
        public int OrderId { get; set; }
        public int WarehouseId { get; set; }
        public string CancelledByUserId { get; set; } = string.Empty;
    }
}
