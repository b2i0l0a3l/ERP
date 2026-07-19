using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Commands
{
    public record DeleteCustomerCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
