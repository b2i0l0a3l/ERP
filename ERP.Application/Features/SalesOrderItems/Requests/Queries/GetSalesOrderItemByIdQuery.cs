using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Requests.Queries
{
    public record GetSalesOrderItemByIdQuery : IRequest<Result<SalesOrderItemDTO>>
    {
        public int Id { get; set; }
    }
}
