using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Inventories.Requests.Commands
{
    public record DeleteInventoryCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
