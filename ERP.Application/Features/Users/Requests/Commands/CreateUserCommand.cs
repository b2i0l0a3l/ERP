using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Requests.Commands
{
    public record CreateUserCommand : IRequest<Result<string>>
    {
        public string Id { get; set; } = string.Empty;
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
