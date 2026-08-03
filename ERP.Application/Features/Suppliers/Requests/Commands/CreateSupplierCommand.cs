using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Requests.Commands
{
    public record CreateSupplierCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
