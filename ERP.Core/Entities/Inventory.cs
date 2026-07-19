using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
public int MinThreshold { get; set; }    
        public virtual Warehouse Warehouse { get; set; } = new();
        public virtual Product Product { get; set; } = new();
    }
}