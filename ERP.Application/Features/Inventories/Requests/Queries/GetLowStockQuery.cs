using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Requests.Queries
{
    public record GetLowStockQuery : IRequest<Result<List<InventoryDTO>>>
    {
    }
}
