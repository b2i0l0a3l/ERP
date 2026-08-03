using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.SalesOrderItems.Requests.Commands
{
    public record CreateSalesOrderItemCommand : IRequest<Result<int>>
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
