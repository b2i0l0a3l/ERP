using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Commands
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, Result<bool>>
    {
        private readonly IInventoryRepo _repo;
        public UpdateInventoryCommandHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateInventoryCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateInventoryParams { Quantity = request.Quantity });
    }
}
