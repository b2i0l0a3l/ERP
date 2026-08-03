using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Commands
{
    public record DeletePurchaseOrderItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
