using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Requests.Queries
{
    public record GetCategoryByIdQuery : IRequest<Result<CategoryDTO>>
    {
        public int Id { get; set; }
    }
}
