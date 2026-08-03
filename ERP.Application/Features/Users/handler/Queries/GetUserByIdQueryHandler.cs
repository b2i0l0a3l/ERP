using ERP.Application.Features.Users.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
    {
        private readonly IUserRepo _repo;
        public GetUserByIdQueryHandler(IUserRepo repo) => _repo = repo;
        public async ValueTask<Result<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
