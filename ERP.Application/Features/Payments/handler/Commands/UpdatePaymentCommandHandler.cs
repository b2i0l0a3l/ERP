using ERP.Application.Features.Payments.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Commands
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<bool>>
    {
        private readonly IPaymentRepo _repo;
        public UpdatePaymentCommandHandler(IPaymentRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdatePaymentCommand request, CancellationToken ct)
            => await _repo.UpdatePayment(request.PaymentId, request.NewAmount, request.PaymentMethod, ct);
    }
}
