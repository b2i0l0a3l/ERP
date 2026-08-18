using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Commands
{
    public class TransferStockCommandHandler : IRequestHandler<TransferStockCommand, Result<bool>>
    {
        private readonly IInventoryRepo _repo;
        public TransferStockCommandHandler(IInventoryRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(TransferStockCommand request, CancellationToken ct)
            => await _repo.TransferStock(request.FromWarehouseId, request.ToWarehouseId, request.ProductId, request.Quantity, request.AdjustedByUserId, request.Reason, ct);
    }
}
