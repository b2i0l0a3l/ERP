using ERP.Application.Features.Users.Requests.Commands;
using ERP.Core.EntityParams.userParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>>
    {
        private readonly IUserRepo _repo;
        public CreateUserCommandHandler(IUserRepo repo) => _repo = repo;
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken ct)
            => await _repo.Add(new AddUserParams { Id = request.Id, FristName = request.FristName, LastName = request.LastName, Email = request.Email, PasswordHash = request.PasswordHash, PhoneNumber = request.PhoneNumber, IsActive = request.IsActive });
    }
}
