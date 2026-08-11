using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Features.Return.Requests.Commands;
using ERP.Core.EntityParams.returnParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Return.Commands
{
    public class CreateReturnCommandHandler : IRequestHandler<CreateReturnCommand, Result<int>>
    {
        private readonly IReturnRepo _repo;
        private readonly ICurrentUserService _CurrentUser;

        public CreateReturnCommandHandler(IReturnRepo repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _CurrentUser = currentUser;
        }

        public async ValueTask<Result<int>> Handle(CreateReturnCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            var returnParam = new ReturnParam
            {
                WarehouseId = request.WarehouseId,
                SaleOrderId = request.SaleOrderId,
                Reason = request.Reason,
                Status = request.Status,
                CreatedByUserId = _CurrentUser.UserId,
                Items = request.Items.Select(item => new ReturnItemParam
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    RefundAmount = item.RefundAmount,
                    Condition = item.Condition
                }).ToList()
            };

            return await _repo.Return(returnParam);
        }
    }
}
