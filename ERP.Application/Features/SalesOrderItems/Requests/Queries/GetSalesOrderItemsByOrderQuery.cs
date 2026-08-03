using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Requests.Queries
{
    public record GetSalesOrderItemsByOrderQuery : IRequest<Result<List<SalesOrderItemDTO>>>
    {
        public int SalesOrderId { get; set; }
    }
}
