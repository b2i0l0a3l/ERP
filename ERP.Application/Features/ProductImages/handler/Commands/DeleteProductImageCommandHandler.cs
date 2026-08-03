using ERP.Application.Features.ProductImages.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.ProductImages.Commands
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, Result<bool>>
    {
        private readonly IProductImageRepo _repo;
        public DeleteProductImageCommandHandler(IProductImageRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteProductImageCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
