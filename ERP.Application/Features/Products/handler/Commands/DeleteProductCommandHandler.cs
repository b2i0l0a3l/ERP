using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        private readonly IProductRepo _repo;
        public DeleteProductCommandHandler(IProductRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
