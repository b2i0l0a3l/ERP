using ERP.Application.Features.SalesOrders.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Commands
{
    public class DeleteSalesOrderCommandHandler : IRequestHandler<DeleteSalesOrderCommand, Result<bool>>
    {
        private readonly ISalesOrderRepo _repo;
        private readonly ICurrentUserService _CurrentUser;
        public DeleteSalesOrderCommandHandler(ISalesOrderRepo repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _CurrentUser = currentUser;
        }
        public async ValueTask<Result<bool>> Handle(DeleteSalesOrderCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            return await _repo.Delete(request.Id, _CurrentUser.UserId, request.WarehouseId);
        }
    }
}
