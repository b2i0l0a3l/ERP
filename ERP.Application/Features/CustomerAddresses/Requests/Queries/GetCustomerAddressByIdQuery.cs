using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerAddresses.Requests.Queries
{
    public record GetCustomerAddressByIdQuery : IRequest<Result<CustomerAddressDTO>>
    {
        public int Id { get; set; }
    }
}
