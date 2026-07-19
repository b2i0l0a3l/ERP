using ERP.Application.Features.CustomerAddresses.Requests.Commands;
using ERP.Core.EntityParams.customerAddressParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerAddresses.Commands
{
    public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateCustomerAddressCommand, Result<int>>
    {
        private readonly ICustomerAddressRepo _repo;
        public CreateCustomerAddressCommandHandler(ICustomerAddressRepo repo) => _repo = repo;
        public async Task<Result<int>> Handle(CreateCustomerAddressCommand request, CancellationToken ct)
            => await _repo.Add(new AddCustomerAddressParams { CustomerId = request.CustomerId, Name = request.Name, Description = request.Description });
    }
}
