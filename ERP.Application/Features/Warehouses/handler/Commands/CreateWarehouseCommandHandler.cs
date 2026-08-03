using ERP.Application.Features.Warehouses.Requests.Commands;
using ERP.Core.EntityParams.warehouseParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Warehouses.Commands
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Result<int>>
    {
        private readonly IWarehouseRepo _repo;
        public CreateWarehouseCommandHandler(IWarehouseRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateWarehouseCommand request, CancellationToken ct)
            => await _repo.Add(new AddWarehouseParams { Name = request.Name });
    }
}
