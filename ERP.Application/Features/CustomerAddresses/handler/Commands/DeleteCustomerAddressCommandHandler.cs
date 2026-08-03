using ERP.Application.Features.CustomerAddresses.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerAddresses.Commands
{
    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, Result<bool>>
    {
        private readonly ICustomerAddressRepo _repo;
        public DeleteCustomerAddressCommandHandler(ICustomerAddressRepo repo) => _repo = repo;
        public async ValueTask<Result<bool>> Handle(DeleteCustomerAddressCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
