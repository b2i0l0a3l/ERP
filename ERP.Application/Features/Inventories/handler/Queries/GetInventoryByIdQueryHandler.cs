using ERP.Application.Features.Inventories.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Queries
{
    public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, Result<InventoryDTO>>
    {
        private readonly IInventoryRepo _repo;
        public GetInventoryByIdQueryHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<InventoryDTO>> Handle(GetInventoryByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
