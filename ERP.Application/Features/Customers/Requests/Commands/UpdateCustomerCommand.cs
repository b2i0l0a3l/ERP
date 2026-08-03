using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Customers.Requests.Commands
{
    public record UpdateCustomerCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
