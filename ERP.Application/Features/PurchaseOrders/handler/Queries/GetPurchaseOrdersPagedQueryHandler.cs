using ERP.Application.Features.PurchaseOrders.Requests.Queries;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Queries
{
    public class GetPurchaseOrdersPagedQueryHandler : IRequestHandler<GetPurchaseOrdersPagedQuery, Result<PagedResult<PurchaseOrderDTO>>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public GetPurchaseOrdersPagedQueryHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<PurchaseOrderDTO>>> Handle(GetPurchaseOrdersPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, SupplierId = request.SupplierId });
    }
}
