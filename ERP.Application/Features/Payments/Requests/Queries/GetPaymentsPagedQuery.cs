using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Payments.Requests.Queries
{
    public record GetPaymentsPagedQuery : IRequest<Result<PagedResult<PaymentDTO>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
    }
}
