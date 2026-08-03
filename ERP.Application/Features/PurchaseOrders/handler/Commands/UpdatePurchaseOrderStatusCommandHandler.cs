using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class UpdatePurchaseOrderStatusCommandHandler : IRequestHandler<UpdatePurchaseOrderStatusCommand, Result<bool>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public UpdatePurchaseOrderStatusCommandHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdatePurchaseOrderStatusCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdatePurchaseOrderParams { OrderStatus = (enStatus)request.Status });
    }
}
