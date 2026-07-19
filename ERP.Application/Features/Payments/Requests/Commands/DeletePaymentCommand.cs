using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Payments.Requests.Commands
{
    public record DeletePaymentCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
