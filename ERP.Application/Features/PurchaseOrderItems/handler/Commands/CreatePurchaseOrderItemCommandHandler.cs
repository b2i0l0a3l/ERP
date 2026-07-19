using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using ERP.Core.EntityParams.purchaseOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Commands
{
    public class CreatePurchaseOrderItemCommandHandler : IRequestHandler<CreatePurchaseOrderItemCommand, Result<int>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public CreatePurchaseOrderItemCommandHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreatePurchaseOrderItemCommand request, CancellationToken ct)
            => await _repo.Add(new AddPurchaseOrderItemParams { PurchaseOrderId = request.PurchaseOrderId, ProductId = request.ProductId, Quantity = request.Quantity, Price = request.Price });
    }
}
