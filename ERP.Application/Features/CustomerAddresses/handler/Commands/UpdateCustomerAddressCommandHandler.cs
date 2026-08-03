using ERP.Application.Features.CustomerAddresses.Requests.Commands;
using ERP.Core.EntityParams.customerAddressParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Commands
{
    public class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, Result<bool>>
    {
        private readonly ICustomerAddressRepo _repo;
        public UpdateCustomerAddressCommandHandler(ICustomerAddressRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(UpdateCustomerAddressCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateCustomerAddressParams { Name = request.Name, Description = request.Description });
    }
}
