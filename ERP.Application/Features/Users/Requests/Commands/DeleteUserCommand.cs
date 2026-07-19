using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Requests.Commands
{
    public record DeleteUserCommand : IRequest<Result<bool>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
