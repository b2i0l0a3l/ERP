using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Requests.Commands
{
    public record UpdatePaymentCommand : IRequest<Result<bool>>
    {
        public int PaymentId { get; set; }
        public decimal NewAmount { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
