using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Commands
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Result<int>>
    {
        private readonly IInventoryRepo _repo;
        public CreateInventoryCommandHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreateInventoryCommand request, CancellationToken ct)
            => await _repo.Add(new AddInventoryParams { WarehouseId = request.WarehouseId, ProductId = request.ProductId, Quantity = request.Quantity });
    }
}
