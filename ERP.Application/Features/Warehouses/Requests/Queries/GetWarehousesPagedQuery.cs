using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Queries
{
    public record GetWarehousesPagedQuery : IRequest<Result<PagedResult<WarehouseDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Name { get; set; }
    }
}
