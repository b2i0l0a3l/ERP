using ERP.Application.Features.Inventories.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Commands
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, Result<bool>>
    {
        private readonly IInventoryRepo _repo;
        public DeleteInventoryCommandHandler(IInventoryRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteInventoryCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
