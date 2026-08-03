using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands
{
    public record DeleteCustomerPhoneNumberCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
