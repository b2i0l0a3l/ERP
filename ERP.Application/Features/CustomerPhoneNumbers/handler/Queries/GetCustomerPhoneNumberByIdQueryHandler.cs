using ERP.Application.Features.CustomerPhoneNumbers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerPhoneNumberModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.CustomerPhoneNumbers.Queries
{
    public class GetCustomerPhoneNumberByIdQueryHandler : IRequestHandler<GetCustomerPhoneNumberByIdQuery, Result<CustomerPhoneNumberDTO>>
    {
        private readonly ICustomerPhoneNumberRepo _repo;
        public GetCustomerPhoneNumberByIdQueryHandler(ICustomerPhoneNumberRepo repo) => _repo = repo;
        public async Task<Result<CustomerPhoneNumberDTO>> Handle(GetCustomerPhoneNumberByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
