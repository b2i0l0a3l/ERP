using ERP.Application.Features.Brands.Requests.Commands;
using ERP.Core.EntityParams.brandParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Result<bool>>
    {
        private readonly IBrandRepo _brandRepo;
        public UpdateBrandCommandHandler(IBrandRepo brandRepo) => _brandRepo = brandRepo;
        public async Task<Result<bool>> Handle(UpdateBrandCommand request, CancellationToken ct)
            => await _brandRepo.Update(request.Id, new UpdateBrandParams { Name = request.Name });
    }
}
