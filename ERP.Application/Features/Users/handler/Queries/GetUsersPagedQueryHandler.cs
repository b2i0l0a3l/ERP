using ERP.Application.Features.Users.Requests.Queries;
using ERP.Core.EntityParams.userParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Users.Queries
{
    public class GetUsersPagedQueryHandler : IRequestHandler<GetUsersPagedQuery, Result<PagedResult<UserDTO>>>
    {
        private readonly IUserRepo _repo;
        public GetUsersPagedQueryHandler(IUserRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<UserDTO>>> Handle(GetUsersPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
