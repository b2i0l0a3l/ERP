using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Requests.Commands
{
    public record DeleteReturnCommand : IRequest<Result>
    {
        public int ReturnId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
