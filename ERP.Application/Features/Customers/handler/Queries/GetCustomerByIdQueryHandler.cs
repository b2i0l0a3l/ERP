using ERP.Application.Features.Customers.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDTO>>
    {
        private readonly ICustomerRepo _repo;
        public GetCustomerByIdQueryHandler(ICustomerRepo repo) => _repo = repo;
        public async Task<Result<CustomerDTO>> Handle(GetCustomerByIdQuery request, CancellationToken ct)
            => await _repo.GetById(request.Id);
    }
}
