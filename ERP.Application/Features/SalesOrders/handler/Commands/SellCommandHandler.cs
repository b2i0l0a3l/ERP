using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class SellCommandHandler : IRequestHandler<SellCommand, Result<int>>
    {
        private readonly ISalesOrderRepo _repo;
        public SellCommandHandler(ISalesOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(SellCommand request, CancellationToken ct)
            => await _repo.Sell(new SellParams
            {
                WarehouseId = request.WarehouseId,
                CustomerId = request.CustomerId,
                Discount = request.Discount,
                CreatedByUserId = request.CreatedByUserId,
                PaymentStatus = request.PaymentStatus,
                Items = request.Items
            });
    }
}
