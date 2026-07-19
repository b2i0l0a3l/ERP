using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using ERP.Core.EntityParams.customerPhoneNumberParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerPhoneNumbers.Commands
{
    public class UpdateCustomerPhoneNumberCommandHandler : IRequestHandler<UpdateCustomerPhoneNumberCommand, Result<bool>>
    {
        private readonly ICustomerPhoneNumberRepo _repo;
        public UpdateCustomerPhoneNumberCommandHandler(ICustomerPhoneNumberRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(UpdateCustomerPhoneNumberCommand request, CancellationToken ct)
            => await _repo.Update(request.Id, new UpdateCustomerPhoneNumberParams { PhoneNumber = request.PhoneNumber });
    }
}
