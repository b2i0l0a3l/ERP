using ERP.Application.Features.Brands.Requests.Commands;
using ERP.Core.EntityParams.brandParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result<int>>
    {
        private readonly IBrandRepo _brandRepo;
        public CreateBrandCommandHandler(IBrandRepo brandRepo) => _brandRepo = brandRepo;
        public async ValueTask<Result<int>> Handle(CreateBrandCommand request, CancellationToken ct)
            => await _brandRepo.Add(new AddBrandParams { Name = request.Name });
    }
}
