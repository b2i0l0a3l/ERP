using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record DeletePurchaseOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
