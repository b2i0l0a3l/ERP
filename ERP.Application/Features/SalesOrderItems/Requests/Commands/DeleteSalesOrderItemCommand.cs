using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrderItems.Requests.Commands
{
    public record DeleteSalesOrderItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
