using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using ERP.Core.EntityParams.customerPhoneNumberParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.CustomerPhoneNumbers.Commands
{
    public class CreateCustomerPhoneNumberCommandHandler : IRequestHandler<CreateCustomerPhoneNumberCommand, Result<int>>
    {
        private readonly ICustomerPhoneNumberRepo _repo;
        public CreateCustomerPhoneNumberCommandHandler(ICustomerPhoneNumberRepo repo) => _repo = repo;
        public async ValueTask<Result<int>> Handle(CreateCustomerPhoneNumberCommand request, CancellationToken ct)
            => await _repo.Add(new AddCustomerPhoneNumberParams { CustomerId = request.CustomerId, PhoneNumber = request.PhoneNumber });
    }
}
