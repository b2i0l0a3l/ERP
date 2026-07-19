using ERP.Application.Features.PurchaseOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Commands
{
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, Result<bool>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public DeletePurchaseOrderCommandHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeletePurchaseOrderCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
