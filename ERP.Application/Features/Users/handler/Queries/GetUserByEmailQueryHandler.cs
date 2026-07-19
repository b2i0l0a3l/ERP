using ERP.Application.Features.Users.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Queries
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Result<UserDTO>>
    {
        private readonly IUserRepo _repo;
        public GetUserByEmailQueryHandler(IUserRepo repo) => _repo = repo;
        public async Task<Result<UserDTO>> Handle(GetUserByEmailQuery request, CancellationToken ct)
            => await _repo.GetByEmail(request.Email);
    }
}
