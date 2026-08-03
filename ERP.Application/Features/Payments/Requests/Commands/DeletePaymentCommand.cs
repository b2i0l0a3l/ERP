using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Requests.Commands
{
    public record DeletePaymentCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
