using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands
{
    public record CreateCustomerPhoneNumberCommand : IRequest<Result<int>>
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
