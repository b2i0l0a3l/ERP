using ERP.Application.Features.Products.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        private readonly IProductRepo _repo;
        private readonly ICurrentUserService _CurrentUser;
        public DeleteProductCommandHandler(IProductRepo repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _CurrentUser = currentUser;
        }
        public async ValueTask<Result<bool>> Handle(DeleteProductCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            return await _repo.Delete(request.Id, _CurrentUser.UserId, ct);
        }
    }
}
