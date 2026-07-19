using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Queries
{
    public record GetWarehouseByNameQuery : IRequest<Result<WarehouseDTO>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
