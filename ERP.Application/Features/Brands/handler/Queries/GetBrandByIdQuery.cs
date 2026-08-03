using ERP.Application.Features.Brands.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Queries
{

    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<BrandDTO>>
    {
        private readonly IBrandRepo _repo;
        public GetBrandByIdQueryHandler(IBrandRepo repo) => _repo = repo;
        public async ValueTask<Result<BrandDTO>> Handle(GetBrandByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
