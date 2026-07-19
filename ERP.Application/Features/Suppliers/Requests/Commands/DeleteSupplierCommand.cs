using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Requests.Commands
{
    public record DeleteSupplierCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
