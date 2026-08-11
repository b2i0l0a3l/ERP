using ERP.Core.enums;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Requests.Queries
{
    public record GetSalesOrdersPagedQuery : IRequest<Result<PagedResult<SalesOrderDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? CustomerId { get; set; }
        public enPaymentStatus? PaymentStatus { get; set; }
    }
}
