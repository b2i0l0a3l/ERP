using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.EntityParams.invoiceParams
{
    public class CreateCompleteInvoiceParams
    {
        public int? OrderId { get; set; }
         public enInvoiceType Type { get; set; }
        public enInvoiceStatus Status { get; set; } = enInvoiceStatus.Draft;
        public int? CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int? SupplierId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? Notes { get; set; }
        public string? CreatedByUserId { get; set; }
        public List<InvoiceItemRecord> Items = new List<InvoiceItemRecord>();
    }
    public record InvoiceItemRecord
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitePrice { get; set; }
        public decimal TaxRate { get; set; }
        public string? Description { get; set; }
    }
}
