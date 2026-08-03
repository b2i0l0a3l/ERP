using ERP.Application.Features.Warehouses.Requests.Commands;
using ERP.Core.EntityParams.warehouseParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Warehouses.Commands
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, Result<bool>>
    {
        private readonly IWarehouseRepo _repo;
        public UpdateWarehouseCommandHandler(IWarehouseRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateWarehouseCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateWarehouseParams { Name = request.Name });
    }
}
