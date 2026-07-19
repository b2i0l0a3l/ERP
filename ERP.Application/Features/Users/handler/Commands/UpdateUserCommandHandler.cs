using ERP.Application.Features.Users.Requests.Commands;
using ERP.Core.EntityParams.userParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<bool>>
    {
        private readonly IUserRepo _repo;
        public UpdateUserCommandHandler(IUserRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateUserParams { FristName = request.FristName, LastName = request.LastName, Email = request.Email, PhoneNumber = request.PhoneNumber, IsActive = request.IsActive });
    }
}
