using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record UpdateInventoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
