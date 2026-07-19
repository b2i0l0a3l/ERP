using ERP.Application.Features.Brands.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Commands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<bool>>
    {
        private readonly IBrandRepo _brandRepo;
        public DeleteBrandCommandHandler(IBrandRepo brandRepo) => _brandRepo = brandRepo;
        public async Task<Result<bool>> Handle(DeleteBrandCommand request, CancellationToken ct)
            => await _brandRepo.Delete(request.Id);
    }
}
