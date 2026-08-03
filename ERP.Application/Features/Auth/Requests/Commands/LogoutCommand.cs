using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Requests.Commands
{
    public record LogoutCommand : IRequest<Result<bool>>
    {
        public string Email { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
