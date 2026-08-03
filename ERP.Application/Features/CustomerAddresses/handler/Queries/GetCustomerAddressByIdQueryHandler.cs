using ERP.Application.Features.CustomerAddresses.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Queries
{
    public class GetCustomerAddressByIdQueryHandler : IRequestHandler<GetCustomerAddressByIdQuery, Result<CustomerAddressDTO>>
    {
        private readonly ICustomerAddressRepo _repo;
        public GetCustomerAddressByIdQueryHandler(ICustomerAddressRepo repo) => _repo = repo;
        public async ValueTask<Result<CustomerAddressDTO>> Handle(GetCustomerAddressByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
