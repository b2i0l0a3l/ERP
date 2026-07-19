using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Queries
{
    public record GetWarehouseByIdQuery : IRequest<Result<WarehouseDTO>>
    {
        public int Id { get; set; }
    }
}
