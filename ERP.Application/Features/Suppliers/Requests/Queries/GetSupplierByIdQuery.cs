using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Suppliers.Requests.Queries
{
    public record GetSupplierByIdQuery : IRequest<Result<SupplierDTO>>
    {
        public int Id { get; set; }
    }
}
