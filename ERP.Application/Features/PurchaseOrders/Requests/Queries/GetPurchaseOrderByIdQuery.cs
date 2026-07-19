using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.PurchaseOrders.Requests.Queries
{
    public record GetPurchaseOrderByIdQuery : IRequest<Result<PurchaseOrderDTO>>
    {
        public int Id { get; set; }
    }
}
