using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class DeleteSalesOrderCommandHandler : IRequestHandler<DeleteSalesOrderCommand, Result<bool>>
    {
        private readonly ISalesOrderRepo _repo;
        public DeleteSalesOrderCommandHandler(ISalesOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteSalesOrderCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id, request.UserId, request.WarehouseId);
    }
}
