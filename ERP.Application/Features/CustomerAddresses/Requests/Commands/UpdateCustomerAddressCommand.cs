using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Requests.Commands
{
    public record UpdateCustomerAddressCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
