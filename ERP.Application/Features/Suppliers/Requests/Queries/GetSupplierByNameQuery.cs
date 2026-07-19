using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Requests.Queries
{
    public record GetSupplierByNameQuery : IRequest<Result<SupplierDTO>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
