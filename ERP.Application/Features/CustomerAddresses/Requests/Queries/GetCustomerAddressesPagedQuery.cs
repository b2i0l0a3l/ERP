using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Requests.Queries
{
    public record GetCustomerAddressesPagedQuery : IRequest<Result<PagedResult<CustomerAddressDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? CustomerId { get; set; }
    }
}
