using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Customers.Requests.Commands
{
    public record CreateCustomerCommand : IRequest<Result<int>>
    {
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
