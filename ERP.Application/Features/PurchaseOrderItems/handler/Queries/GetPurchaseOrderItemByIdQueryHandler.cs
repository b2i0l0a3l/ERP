using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Queries
{
    public class GetPurchaseOrderItemByIdQueryHandler : IRequestHandler<GetPurchaseOrderItemByIdQuery, Result<PurchaseOrderItemDTO>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public GetPurchaseOrderItemByIdQueryHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<PurchaseOrderItemDTO>> Handle(GetPurchaseOrderItemByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
