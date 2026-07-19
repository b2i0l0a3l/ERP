using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Suppliers.Requests.Queries
{
    public record GetSupplierOrdersQuery : IRequest<Result<PagedResult<PurchaseOrderDTO>>>
    {
        public int SupplierId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
