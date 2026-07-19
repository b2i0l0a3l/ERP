using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Commands
{
    public record UpdatePurchaseOrderItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
