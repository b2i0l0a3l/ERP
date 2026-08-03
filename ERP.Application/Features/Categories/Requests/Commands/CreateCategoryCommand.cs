using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Requests.Commands
{
    public record CreateCategoryCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
