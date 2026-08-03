using ERP.Application.Features.Warehouses.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Warehouses.Queries
{
    public class GetWarehouseByNameQueryHandler : IRequestHandler<GetWarehouseByNameQuery, Result<WarehouseDTO>>
    {
        private readonly IWarehouseRepo _repo;
        public GetWarehouseByNameQueryHandler(IWarehouseRepo repo) => _repo = repo;
        public async ValueTask<Result<WarehouseDTO>> Handle(GetWarehouseByNameQuery request, CancellationToken ct)
            => await _repo.GetByName(request.Name);
    }
}
