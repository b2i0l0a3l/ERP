using ERP.Application.Features.Categories.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Queries
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, Result<CategoryDTO>>
    {
        private readonly ICategoryRepo _repo;
        public GetCategoryByNameQueryHandler(ICategoryRepo repo) => _repo = repo;
        public async Task<Result<CategoryDTO>> Handle(GetCategoryByNameQuery request, CancellationToken ct)
            => await _repo.GetByName(request.Name);
    }
}
