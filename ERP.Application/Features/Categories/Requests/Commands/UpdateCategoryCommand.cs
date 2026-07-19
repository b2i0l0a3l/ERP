using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Requests.Commands
{
    public record UpdateCategoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
