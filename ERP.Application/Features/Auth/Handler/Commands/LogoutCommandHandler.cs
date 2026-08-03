using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.EntityParams.AuthParams.RefreshToken;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Handler.Commands
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<bool>>
    {
        private readonly IAuthService _authService;
        public LogoutCommandHandler(IAuthService authService) => _authService = authService;

        public async ValueTask<Result<bool>> Handle(LogoutCommand request, CancellationToken ct)
        {
            var tokenRequest = new RefreshTokenRequest
            {
                Email = request.Email,
                RefreshToken = request.RefreshToken
            };
            return await _authService.Logout(tokenRequest);
        }
    }
}
