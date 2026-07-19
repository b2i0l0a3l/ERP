using ERP.Application.Features.Categories.Requests.Queries;
using ERP.Core.EntityParams.categoryParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Queries
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, Result<PagedResult<CategoryDTO>>>
    {
        private readonly ICategoryRepo _repo;
        public GetCategoriesPagedQueryHandler(ICategoryRepo repo) => _repo = repo;
        public async Task<Result<PagedResult<CategoryDTO>>> Handle(GetCategoriesPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
