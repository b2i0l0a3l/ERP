using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Requests.Commands
{
    public record RegisterCommand : IRequest<Result<RegisterResponse>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }
}
