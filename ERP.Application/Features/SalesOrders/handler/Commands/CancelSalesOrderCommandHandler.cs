using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class CancelSalesOrderCommandHandler : IRequestHandler<CancelSalesOrderCommand, Result<bool>>
    {
        private readonly ISalesOrderRepo _repo;
        public CancelSalesOrderCommandHandler(ISalesOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(CancelSalesOrderCommand request, CancellationToken ct)
            => await _repo.CancelSalesOrder(request.OrderId, request.WarehouseId, request.CancelledByUserId, ct);
    }
}
