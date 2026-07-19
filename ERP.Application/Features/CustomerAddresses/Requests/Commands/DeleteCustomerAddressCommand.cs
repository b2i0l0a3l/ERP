using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerAddresses.Requests.Commands
{
    public record DeleteCustomerAddressCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
