using ERP.Application.Features.Suppliers.Requests.Queries;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Queries
{
    public class GetSupplierOrdersQueryHandler : IRequestHandler<GetSupplierOrdersQuery, Result<PagedResult<PurchaseOrderDTO>>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public GetSupplierOrdersQueryHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<PurchaseOrderDTO>>> Handle(GetSupplierOrdersQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, SupplierId = request.SupplierId });
    }
}
