using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class SalesOrderItem : BaseEntity
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public virtual Product Product { get; set; } = new();
        public virtual SalesOrder SalesOrder { get; set; } = new();
    }
}