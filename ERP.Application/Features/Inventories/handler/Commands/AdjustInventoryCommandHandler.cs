using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Commands
{
    public class AdjustInventoryCommandHandler : IRequestHandler<AdjustInventoryCommand, Result<bool>>
    {
        private readonly IInventoryRepo _repo;
        public AdjustInventoryCommandHandler(IInventoryRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(AdjustInventoryCommand request, CancellationToken ct)
            => await _repo.AdjustInventory(request.WarehouseId, request.ProductId, request.NewQuantity, request.AdjustedByUserId, request.Reason, ct);
    }
}
