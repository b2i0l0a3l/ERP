using ERP.Application.Features.SalesOrders.Requests.Queries;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Queries
{
    public class GetSalesOrdersPagedQueryHandler : IRequestHandler<GetSalesOrdersPagedQuery, Result<PagedResult<SalesOrderDTO>>>
    {
        private readonly ISalesOrderRepo _repo;
        public GetSalesOrdersPagedQueryHandler(ISalesOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<SalesOrderDTO>>> Handle(GetSalesOrdersPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, CustomerId = request.CustomerId, PaymentStatus = request.PaymentStatus });
    }
}
