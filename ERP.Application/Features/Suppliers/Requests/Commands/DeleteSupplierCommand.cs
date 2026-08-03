using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Requests.Commands
{
    public record DeleteSupplierCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
