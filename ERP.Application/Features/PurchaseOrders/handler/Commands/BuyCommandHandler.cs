using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class BuyCommandHandler : IRequestHandler<BuyCommand, Result<int>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public BuyCommandHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(BuyCommand request, CancellationToken ct)
            => await _repo.Buy(new BuyParams
            {
                SupplierId = request.SupplierId,
                WarehouseId = request.WarehouseId,
                CreatedByUserId = request.CreatedByUserId,
                Items = request.Items
            });
    }
}
