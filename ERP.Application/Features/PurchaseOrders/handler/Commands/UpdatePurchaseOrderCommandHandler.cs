using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.enums;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class UpdatePurchaseOrderCommandHandler : IRequestHandler<UpdatePurchaseOrderCommand, Result<bool>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public UpdatePurchaseOrderCommandHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdatePurchaseOrderCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdatePurchaseOrderParams { OrderStatus = (enStatus)request.Status, Total = request.Total });
    }
}
