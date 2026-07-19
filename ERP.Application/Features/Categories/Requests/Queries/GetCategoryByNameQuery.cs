using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Requests.Queries
{
    public record GetCategoryByNameQuery : IRequest<Result<CategoryDTO>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
