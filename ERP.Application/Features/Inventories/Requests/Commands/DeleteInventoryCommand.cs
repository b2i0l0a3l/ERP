using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record DeleteInventoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
