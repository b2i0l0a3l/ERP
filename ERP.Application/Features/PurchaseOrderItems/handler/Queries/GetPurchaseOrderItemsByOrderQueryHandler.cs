using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Queries
{
    public class GetPurchaseOrderItemsByOrderQueryHandler : IRequestHandler<GetPurchaseOrderItemsByOrderQuery, Result<PagedResult<PurchaseOrderItemDTO>>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public GetPurchaseOrderItemsByOrderQueryHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<PurchaseOrderItemDTO>>> Handle(GetPurchaseOrderItemsByOrderQuery request, CancellationToken ct)
            => await _repo.GetByPurchaseOrderId(request.PurchaseOrderId, request.PageNumber, request.PageSize);
    }
}
