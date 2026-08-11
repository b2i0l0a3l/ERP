using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.enums;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrders.Requests.Commands
{
    public record SellCommand : IRequest<Result<int>>
    {
        public int WarehouseId { get; set; }
        public int? CustomerId { get; set; }
        public decimal Discount { get; set; }
        public string CreatedByUserId { get; set; } = string.Empty;
        public enPaymentStatus PaymentStatus { get; set; } = enPaymentStatus.Unpaid;
        public IEnumerable<Items> Items { get; set; } = new List<Items>();
    }
}
