using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.EntityParams.purchaseOrderParams
{
    public record BuyParams
    {
        public string CreatedByUserId { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
        public List<BuyItems> Items { get; set; } = new List<BuyItems>();
    }
    public record BuyItems
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
    }
}