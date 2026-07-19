using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Warehouses.Requests.Commands
{
    public record DeleteWarehouseCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
