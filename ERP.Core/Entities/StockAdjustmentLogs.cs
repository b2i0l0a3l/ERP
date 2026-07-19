using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class StockAdjustmentLog : BaseEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int OldQuantity { get; set; }
        public int NewQuantity { get; set; }
        public int Difference { get; set; }

        public string? Reason { get; set; }

        public string? AdjustedByUserId { get; set; }
        public User? AdjustedByUser { get; set; }

    }
}