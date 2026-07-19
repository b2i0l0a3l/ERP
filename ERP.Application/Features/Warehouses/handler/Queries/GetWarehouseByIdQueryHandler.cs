using ERP.Application.Features.Warehouses.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Queries
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, Result<WarehouseDTO>>
    {
        private readonly IWarehouseRepo _repo;
        public GetWarehouseByIdQueryHandler(IWarehouseRepo repo) => _repo = repo;
        public async Task<Result<WarehouseDTO>> Handle(GetWarehouseByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
