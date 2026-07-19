using ERP.Application.Features.ProductImages.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.ProductImages.Commands
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, Result<bool>>
    {
        private readonly IProductImageRepo _repo;
        public DeleteProductImageCommandHandler(IProductImageRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteProductImageCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
