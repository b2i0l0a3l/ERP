using ERP.Application.Features.Brands.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Brands.Queries
{
    public class GetBrandByNameQueryHandler : IRequestHandler<GetBrandByNameQuery, Result<BrandDTO>>
    {
        private readonly IBrandRepo _repo;
        public GetBrandByNameQueryHandler(IBrandRepo repo) => _repo = repo;
        public async Task<Result<BrandDTO>> Handle(GetBrandByNameQuery request, CancellationToken ct)
            => await _repo.GetByName(request.Name);
    }
}
