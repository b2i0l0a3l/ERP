using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Queries
{
    public record GetCustomersPagedQuery : IRequest<Result<PagedResult<CustomerDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
