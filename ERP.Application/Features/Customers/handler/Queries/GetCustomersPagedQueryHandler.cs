using ERP.Application.Features.Customers.Requests.Queries;
using ERP.Core.EntityParams.customerParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Queries
{
    public class GetCustomersPagedQueryHandler : IRequestHandler<GetCustomersPagedQuery, Result<PagedResult<CustomerDTO>>>
    {
        private readonly ICustomerRepo _repo;
        public GetCustomersPagedQueryHandler(ICustomerRepo repo) => _repo = repo;
        public async ValueTask<Result<PagedResult<CustomerDTO>>> Handle(GetCustomersPagedQuery request, CancellationToken ct)
            => await _repo.GetPaged(new GetPagedAsyncParams { PageNumber = request.PageNumber, PageSize = request.PageSize, Name = request.Name });
    }
}
