using ERP.Application.Features.Invoices.Requests.Commands;
using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Result<int>>
    {
        private readonly IInvoiceRepo _repo;
        private readonly ICurrentUserService _CurrentUser;
        public CreateInvoiceCommandHandler(ICurrentUserService CurrentUser, IInvoiceRepo repo)
        {

            _CurrentUser = CurrentUser;
            _repo = repo;
        }
        public async ValueTask<Result<int>> Handle(CreateInvoiceCommand request, CancellationToken ct)
        {
            if (!_CurrentUser.IsAuthenticated || string.IsNullOrEmpty(_CurrentUser.UserId))
                return Errors.UserNotAuthorized;

            return await _repo.CreateCompleteInvoice(new CreateCompleteInvoiceParams
            {
                Type = request.Type,
                Status = request.Status,
                CustomerId = request.CustomerId,
                SupplierId = request.SupplierId,
                SubTotal = request.SubTotal,
                DiscountAmount = request.DiscountAmount,
                Notes = request.Notes,
                Items = request.items,
WarehouseId = request.WarehouseId,

                CreatedByUserId = _CurrentUser.UserId
            });
        }
    }
}
