using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Queries
{
    public record GetCustomerOrdersQuery : IRequest<Result<PagedResult<SalesOrderDTO>>>
    {
        public int CustomerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
