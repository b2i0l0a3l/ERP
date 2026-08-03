using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Requests.Commands
{
    public record UpdateSalesOrderStatusCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
