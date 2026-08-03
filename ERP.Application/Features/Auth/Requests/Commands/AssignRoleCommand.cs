using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Requests.Commands
{
    public record AssignRoleCommand : IRequest<Result<bool>>
    {
        public string UserId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
