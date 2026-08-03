using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Handler.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterResponse>>
    {
        private readonly IAuthService _authService;
        public RegisterCommandHandler(IAuthService authService) => _authService = authService;

        public async ValueTask<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken ct)
            => await _authService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.PhoneNumber);
    }
}
