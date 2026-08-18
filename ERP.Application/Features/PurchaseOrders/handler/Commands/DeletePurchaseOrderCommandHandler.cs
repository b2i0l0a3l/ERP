using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, Result<bool>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public DeletePurchaseOrderCommandHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeletePurchaseOrderCommand request, CancellationToken ct)
            => await _repo.DeletePurchaseOrder(request.PurchaseOrderId, request.WarehouseId, request.DeletedByUserId, ct);
    }
}
