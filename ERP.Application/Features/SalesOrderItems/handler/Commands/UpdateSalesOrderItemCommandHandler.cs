using ERP.Application.Features.SalesOrderItems.Requests.Commands;
using ERP.Core.EntityParams.salesOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Commands
{
    public class UpdateSalesOrderItemCommandHandler : IRequestHandler<UpdateSalesOrderItemCommand, Result<bool>>
    {
        private readonly ISalesOrderItemRepo _repo;
        public UpdateSalesOrderItemCommandHandler(ISalesOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateSalesOrderItemCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateSalesOrderItemParams { Quantity = request.Quantity, SellingPrice = request.SellingPrice, Discount = request.Discount, Total = request.Total });
    }
}
