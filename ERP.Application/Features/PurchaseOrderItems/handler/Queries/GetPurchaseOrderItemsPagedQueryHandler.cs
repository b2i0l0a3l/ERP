using ERP.Application.Features.PurchaseOrderItems.Requests.Queries;
using ERP.Core.EntityParams.purchaseOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Queries
{
    public class GetPurchaseOrderItemsPagedQueryHandler : IRequestHandler<GetPurchaseOrderItemsPagedQuery, Result<PagedResult<PurchaseOrderItemDTO>>>
    {
        private readonly IPurchaseOrderItemRepo _repo;
        public GetPurchaseOrderItemsPagedQueryHandler(IPurchaseOrderItemRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<PurchaseOrderItemDTO>>> Handle(GetPurchaseOrderItemsPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, PurchaseOrderId = request.PurchaseOrderId });
    }
}
