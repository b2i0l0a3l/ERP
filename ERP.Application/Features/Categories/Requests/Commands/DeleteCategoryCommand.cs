using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Categories.Requests.Commands
{
    public record DeleteCategoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
