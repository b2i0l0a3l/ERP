using ERP.Core.enums;

namespace ERP.Core.EntityParams.salesOrderParams
{
    public record AddSalesOrderParams
    {
        public int? CustomerId { get; set; }
        public enStatus Status { get; set; } = enStatus.Pending;
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
