using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record DeletePurchaseOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
    }
}
