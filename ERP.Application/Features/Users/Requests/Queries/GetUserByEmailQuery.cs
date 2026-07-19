using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Requests.Queries
{
    public record GetUserByEmailQuery : IRequest<Result<UserDTO>>
    {
        public string Email { get; set; } = string.Empty;
    }
}
