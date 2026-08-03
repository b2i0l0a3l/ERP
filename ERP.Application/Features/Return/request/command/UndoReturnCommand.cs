using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Requests.Commands
{
    public record UndoReturnCommand : IRequest<Result>
    {
        public int ReturnId { get; set; }
    }
}
