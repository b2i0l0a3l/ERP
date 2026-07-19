using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class UndoDeleteSalesOrderCommandHandler : IRequestHandler<UndoDeleteSalesOrderCommand, Result<bool>>
    {
        private readonly ISalesOrderRepo _repo;
        public UndoDeleteSalesOrderCommandHandler(ISalesOrderRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UndoDeleteSalesOrderCommand request, CancellationToken ct)
            => await _repo.UndoDelete(request.Id, request.WarehouseId);
    }
}
