using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Requests.Commands
{
    public record RefreshTokenCommand : IRequest<Result<AuthResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
