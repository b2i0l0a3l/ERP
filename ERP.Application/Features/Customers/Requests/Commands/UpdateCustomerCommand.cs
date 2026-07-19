using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Commands
{
    public record UpdateCustomerCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
