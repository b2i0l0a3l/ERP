using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Warehouses.Requests.Commands
{
    public record UpdateWarehouseCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
