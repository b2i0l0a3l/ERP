using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Commands
{
    public class UpdatePurchaseOrderItemCommandHandler : IRequestHandler<UpdatePurchaseOrderItemCommand, Result<bool>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public UpdatePurchaseOrderItemCommandHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdatePurchaseOrderItemCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdatePurchaseOrderItemParams { Quantity = request.Quantity, Price = request.Price });
    }
}
