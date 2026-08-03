using ERP.Application.Features.Auth.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Auth.Handler.Commands
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Result<bool>>
    {
        private readonly IRoleRepo _roleRepo;
        public AssignRoleCommandHandler(IRoleRepo roleRepo) => _roleRepo = roleRepo;

        public async ValueTask<Result<bool>> Handle(AssignRoleCommand request, CancellationToken ct)
            => await _roleRepo.AssignRoleAsync(request.UserId, request.RoleName);
    }
}
