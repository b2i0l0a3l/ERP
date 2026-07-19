using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Queries
{
    public record GetCustomerByIdQuery : IRequest<Result<CustomerDTO>>
    {
        public int Id { get; set; }
    }
}
