using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Requests.Commands
{
    public record CreateCustomerCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
