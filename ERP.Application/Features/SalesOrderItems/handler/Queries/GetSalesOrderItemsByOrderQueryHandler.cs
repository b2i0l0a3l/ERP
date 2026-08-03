using ERP.Application.Features.SalesOrderItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Queries
{
    public class GetSalesOrderItemsByOrderQueryHandler : IRequestHandler<GetSalesOrderItemsByOrderQuery, Result<List<SalesOrderItemDTO>>>
    {
        private readonly ISalesOrderItemRepo _repo;
        public GetSalesOrderItemsByOrderQueryHandler(ISalesOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<List<SalesOrderItemDTO>>> Handle(GetSalesOrderItemsByOrderQuery request, CancellationToken ct)
            => await _repo.GetBySalesOrderId(request.SalesOrderId);
    }
}
