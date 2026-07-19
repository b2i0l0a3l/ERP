using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Requests.Queries
{
    public record GetUsersPagedQuery : IRequest<Result<PagedResult<UserDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
