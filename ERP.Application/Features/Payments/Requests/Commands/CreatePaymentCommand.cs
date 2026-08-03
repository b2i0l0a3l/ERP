using ERP.Core.enums;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Payments.Requests.Commands
{
    public record CreatePaymentCommand : IRequest<Result<int>>
    {
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; }
        public enPaymentMethod PaymentMethod { get; set; } = enPaymentMethod.Cash;
        public string CreatedByUserId { get; set; } = string.Empty;
    }
}
