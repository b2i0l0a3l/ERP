using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Return.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Commands
{
    public class DeleteReturnCommandHandler : IRequestHandler<DeleteReturnCommand, Result>
    {
        private readonly IReturnRepo _repo;
        private readonly ICurrentUserService _CurrentUser;

        public DeleteReturnCommandHandler(IReturnRepo repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _CurrentUser = currentUser;
        }

        public async ValueTask<Result> Handle(DeleteReturnCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            return await _repo.Delete(request.ReturnId, _CurrentUser.UserId);
        }
    }
}
