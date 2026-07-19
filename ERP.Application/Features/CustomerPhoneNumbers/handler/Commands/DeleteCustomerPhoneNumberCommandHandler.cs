using ERP.Application.Features.CustomerPhoneNumbers.Requests.Commands;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerPhoneNumbers.Commands
{
    public class DeleteCustomerPhoneNumberCommandHandler : IRequestHandler<DeleteCustomerPhoneNumberCommand, Result<bool>>
    {
        private readonly ICustomerPhoneNumberRepo _repo;
        public DeleteCustomerPhoneNumberCommandHandler(ICustomerPhoneNumberRepo repo) => _repo = repo;
        public async Task<Result<bool>> Handle(DeleteCustomerPhoneNumberCommand request, CancellationToken ct)
            => await _repo.Delete(request.Id);
    }
}
