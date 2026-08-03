using ERP.Core.Models.CustomerBalanceModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Requests.Queries
{
    public record GetCustomerBalanceQuery : IRequest<Result<CustomerBalanceDTO>>
    {
        public int CustomerId { get; set; }
    }
}
