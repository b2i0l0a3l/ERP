using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.EntityParams.salesOrderParams
{
    public record SellParams
    {
        public int WarehouseId { get; set; }
        public int? CustomerId { get; set; }
        public enPaymentStatus PaymentStatus { get; set; } = enPaymentStatus.Unpaid;
        public decimal Discount { get; set; } = 0;
        public string CreatedByUserId { get; set; } = string.Empty;
        public IEnumerable<Items> Items { get; set; } = new List<Items>();
    }
    public record Items
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal SellingPrice { get; set; }
        
    }
}