using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Requests.Commands
{
    public record DeleteCustomerAddressCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
