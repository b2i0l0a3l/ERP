using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Users.Requests.Commands
{
    public record UpdateUserCommand : IRequest<Result<bool>>
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
