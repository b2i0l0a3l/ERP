using ERP.Application.Features.Brands.Requests.Queries;
using ERP.Core.EntityParams.brandParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Queries
{
    public class GetBrandsPagedQueryHandler : IRequestHandler<GetBrandsPagedQuery, Result<PagedResult<BrandDTO>>>
    {
        private readonly IBrandRepo _repo;
        public GetBrandsPagedQueryHandler(IBrandRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<BrandDTO>>> Handle(GetBrandsPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
