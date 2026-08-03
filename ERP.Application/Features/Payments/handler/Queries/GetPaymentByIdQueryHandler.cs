using ERP.Application.Features.Payments.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Queries
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Result<PaymentDTO>>
    {
        private readonly IPaymentRepo _repo;
        public GetPaymentByIdQueryHandler(IPaymentRepo repo) => _repo = repo;
        public async ValueTask<Result<PaymentDTO>> Handle(GetPaymentByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
