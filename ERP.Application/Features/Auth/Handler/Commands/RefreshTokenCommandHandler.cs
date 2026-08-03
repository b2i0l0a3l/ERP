using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.EntityParams.AuthParams.RefreshToken;
using ERP.Core.Interfaces;
using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Handler.Commands
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
    {
        private readonly IAuthService _authService;
        public RefreshTokenCommandHandler(IAuthService authService) => _authService = authService;

        public async ValueTask<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken ct)
        {
            var refreshTokenReq = new RefreshTokenRequest
            {
                Email = request.Email,
                RefreshToken = request.RefreshToken
            };

            return await _authService.RefreshTokenAsync(refreshTokenReq);
        }
    }
}
