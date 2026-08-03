using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Requests.Queries
{
    public record GetPaymentByIdQuery : IRequest<Result<PaymentDTO>>
    {
        public int Id { get; set; }
    }
}
