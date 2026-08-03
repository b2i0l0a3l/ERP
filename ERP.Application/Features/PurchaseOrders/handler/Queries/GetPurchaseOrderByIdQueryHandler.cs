using ERP.Application.Features.PurchaseOrders.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Queries
{
    public class GetPurchaseOrderByIdQueryHandler : IRequestHandler<GetPurchaseOrderByIdQuery, Result<PurchaseOrderDTO>>
    {
        private readonly IPurchaseOrderRepo _repo;
        public GetPurchaseOrderByIdQueryHandler(IPurchaseOrderRepo repo) => _repo = repo;
        public async ValueTask<Result<PurchaseOrderDTO>> Handle(GetPurchaseOrderByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
