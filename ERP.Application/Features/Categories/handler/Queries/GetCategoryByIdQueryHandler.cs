using ERP.Application.Features.Categories.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDTO>>
    {
        private readonly ICategoryRepo _repo;
        public GetCategoryByIdQueryHandler(ICategoryRepo repo) => _repo = repo;
        public async Task<Result<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
