using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Requests.Commands
{
    public record UndoDeleteSalesOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
    }
}
