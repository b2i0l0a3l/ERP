using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class BuyCommandHandler : IRequestHandler<BuyCommand, Result<int>>
    {
        private readonly IPurchaseOrderRepo _repo;
        private readonly ICurrentUserService _CurrentUser;
        public BuyCommandHandler(IPurchaseOrderRepo repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _CurrentUser = currentUser;
        }
        public async ValueTask<Result<int>> Handle(BuyCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            return await _repo.Buy(new BuyParams
            {
                SupplierId = request.SupplierId,
                WarehouseId = request.WarehouseId,
                CreatedByUserId = _CurrentUser.UserId,
                Items = request.Items
            });
        }
    }
}
