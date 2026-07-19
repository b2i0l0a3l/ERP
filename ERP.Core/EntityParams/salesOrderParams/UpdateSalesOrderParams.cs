using ERP.Core.enums;

namespace ERP.Core.EntityParams.salesOrderParams
{
    public class UpdateSalesOrderParams
    {
        public enStatus Status { get; set; } = enStatus.Pending;
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
