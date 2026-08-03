using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Requests.Queries
{
    public record GetCategoriesPagedQuery : IRequest<Result<PagedResult<CategoryDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
