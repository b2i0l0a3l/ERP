using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Categories.Requests.Commands
{
    public record DeleteCategoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
