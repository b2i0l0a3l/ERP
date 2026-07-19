using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Commands
{
    public record UpdateWarehouseCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
