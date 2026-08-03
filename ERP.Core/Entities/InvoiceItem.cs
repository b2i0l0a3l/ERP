using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public Invoice? Invoice { get; set; }

        public string? Description { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal LineTotal { get; set; }

    }
}