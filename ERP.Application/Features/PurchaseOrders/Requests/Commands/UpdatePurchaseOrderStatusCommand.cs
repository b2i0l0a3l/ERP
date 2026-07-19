using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Requests.Commands
{
    public record UpdatePurchaseOrderStatusCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
