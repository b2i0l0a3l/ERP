using ERP.Application.Features.Customers.Requests.Queries;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Queries
{
    public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, Result<PagedResult<SalesOrderDTO>>>
    {
        private readonly ISalesOrderRepo _repo;
        public GetCustomerOrdersQueryHandler(ISalesOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<SalesOrderDTO>>> Handle(GetCustomerOrdersQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, CustomerId = request.CustomerId });
    }
}
