using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Users.Requests.Queries
{
    public record GetUserByIdQuery : IRequest<Result<UserDTO>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
