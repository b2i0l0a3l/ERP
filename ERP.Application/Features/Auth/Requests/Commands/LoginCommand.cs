using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Requests.Commands
{
    public record LoginCommand : IRequest<Result<AuthResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
