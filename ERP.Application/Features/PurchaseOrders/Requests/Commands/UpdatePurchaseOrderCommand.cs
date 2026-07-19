using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record UpdatePurchaseOrderCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }
    }
}
