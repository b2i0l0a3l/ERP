using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Requests.Queries
{
    public record GetSuppliersPagedQuery : IRequest<Result<PagedResult<SupplierDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
