using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Requests.Commands
{
    public record DeleteSalesOrderItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
