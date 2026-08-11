using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Requests.Queries
{
    public record GetSalesOrderItemsByOrderQuery : IRequest<Result<PagedResult<SalesOrderItemDTO>>>
    {
        public int SalesOrderId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
