using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Core.EntityParams.paymentParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Commands
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<int>>
    {
        private readonly IPaymentRepo _repo;
        public CreatePaymentCommandHandler(IPaymentRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreatePaymentCommand request, CancellationToken ct)
            => await _repo.Pay(new PayParmas
            {
                SaleOrderId = request.SaleOrderId,
                PurchaseOrderId = request.PurchaseOrderId,
                Amount = request.Amount,
                Notes = request.Notes,
                ReferenceNumber = request.ReferenceNumber,
                PaymentMethod = request.PaymentMethod,
                CreatedByUserId = request.CreatedByUserId
            });
    }
}
