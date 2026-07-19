using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrderItems.Requests.Queries
{
    public record GetPurchaseOrderItemByIdQuery : IRequest<Result<PurchaseOrderItemDTO>>
    {
        public int Id { get; set; }
    }
}
