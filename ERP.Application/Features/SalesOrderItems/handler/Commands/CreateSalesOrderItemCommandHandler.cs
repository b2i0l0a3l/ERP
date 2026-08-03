using ERP.Application.Features.SalesOrderItems.Requests.Commands;
using ERP.Core.EntityParams.salesOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Commands
{
    public class CreateSalesOrderItemCommandHandler : IRequestHandler<CreateSalesOrderItemCommand, Result<int>>
    {
        private readonly ISalesOrderItemRepo _repo;
        public CreateSalesOrderItemCommandHandler(ISalesOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateSalesOrderItemCommand request, CancellationToken ct)
            => await _repo.Add(new AddSalesOrderItemParams { SalesOrderId = request.SalesOrderId, ProductId = request.ProductId, Quantity = request.Quantity, SellingPrice = request.SellingPrice, Discount = request.Discount, Total = request.Total });
    }
}
