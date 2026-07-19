using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands
{
    public record DeleteCustomerPhoneNumberCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
