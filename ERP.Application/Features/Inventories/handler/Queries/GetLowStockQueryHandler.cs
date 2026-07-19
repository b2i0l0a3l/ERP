using ERP.Application.Features.Inventories.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Queries
{
    public class GetLowStockQueryHandler : IRequestHandler<GetLowStockQuery, Result<List<InventoryDTO>>>
    {
        private readonly IInventoryRepo _repo;
        public GetLowStockQueryHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<List<InventoryDTO>>> Handle(GetLowStockQuery request, CancellationToken ct)
            => await _repo.GetLowStock();
    }
}
