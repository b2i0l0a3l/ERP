using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.EntityParams.AuthParams.Login;
using ERP.Core.Interfaces;
using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Handler.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService) => _authService = authService;

        public async ValueTask<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken ct)
        {
            var loginRequest = new LoginRequest
            {
                Email = request.Email,
                Password = request.Password
            };
            return await _authService.LoginAsync(loginRequest);
        }
    }
}
