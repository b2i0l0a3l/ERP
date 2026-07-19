using ERP.Application.Features.Warehouses.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Commands
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, Result<bool>>
    {
        private readonly IWarehouseRepo _repo;
        public DeleteWarehouseCommandHandler(IWarehouseRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteWarehouseCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
