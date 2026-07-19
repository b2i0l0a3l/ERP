using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Requests.Commands
{
    public record DeleteSalesOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
    }
}
