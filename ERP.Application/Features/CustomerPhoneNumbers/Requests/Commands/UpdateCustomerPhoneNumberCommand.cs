using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands
{
    public record UpdateCustomerPhoneNumberCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
