using ERP.Application.Features.Inventories.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Queries
{
    public class GetInventoryByProductIdQueryHandler : IRequestHandler<GetInventoryByProductIdQuery, Result<InventoryDTO>>
    {
        private readonly IInventoryRepo _repo;
        public GetInventoryByProductIdQueryHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<InventoryDTO>> Handle(GetInventoryByProductIdQuery request, CancellationToken ct)
            => await _repo.GetByProductId(request.ProductId);
    }
}
