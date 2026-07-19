using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class PurchaseOrderItem : BaseEntity
    {
        public int PurchaseOrderId { get; set; } 
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public virtual PurchaseOrder PurchaseOrder { get; set; } = new();
        public virtual Product Product { get; set; } = new();
    }
}