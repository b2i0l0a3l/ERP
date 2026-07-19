using ERP.Application.Features.PurchaseOrderItems.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Commands
{
    public class DeletePurchaseOrderItemCommandHandler : IRequestHandler<DeletePurchaseOrderItemCommand, Result<bool>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public DeletePurchaseOrderItemCommandHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeletePurchaseOrderItemCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
