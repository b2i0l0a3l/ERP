using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Requests.Commands
{
    public record UpdateSupplierCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
