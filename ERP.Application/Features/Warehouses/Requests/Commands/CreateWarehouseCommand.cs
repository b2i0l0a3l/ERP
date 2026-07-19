using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Commands
{
    public record CreateWarehouseCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
