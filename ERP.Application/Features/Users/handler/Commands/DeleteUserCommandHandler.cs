using ERP.Application.Features.Users.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        private readonly IUserRepo _repo;
        public DeleteUserCommandHandler(IUserRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteUserCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
