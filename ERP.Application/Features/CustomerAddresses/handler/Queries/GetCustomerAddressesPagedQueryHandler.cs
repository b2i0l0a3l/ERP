using ERP.Application.Features.CustomerAddresses.Requests.Queries;
using ERP.Core.EntityParams.customerAddressParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Queries
{
    public class GetCustomerAddressesPagedQueryHandler : IRequestHandler<GetCustomerAddressesPagedQuery, Result<PagedResult<CustomerAddressDTO>>>
    {
        private readonly ICustomerAddressRepo _repo;
        public GetCustomerAddressesPagedQueryHandler(ICustomerAddressRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<CustomerAddressDTO>>> Handle(GetCustomerAddressesPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, CustomerId = request.CustomerId });
    }
}
