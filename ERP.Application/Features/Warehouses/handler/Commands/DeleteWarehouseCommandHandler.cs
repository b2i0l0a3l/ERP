using ERP.Application.Features.Warehouses.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Warehouses.Commands
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, Result<bool>>
    {
        private readonly IWarehouseRepo _repo;
        public DeleteWarehouseCommandHandler(IWarehouseRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteWarehouseCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
