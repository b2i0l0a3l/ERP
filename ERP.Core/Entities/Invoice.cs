using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public string? InvoiceNumber { get; set; } 
        public enInvoiceType Type { get; set; }    
        public enInvoiceStatus Status { get; set; }  
        
        public int? SalesOrderId { get; set; }
        public SalesOrder? SalesOrder { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public int? SupplierId { get; set; }         
        public Supplier? Supplier { get; set; }
        
        public DateTime IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        
        public string? Notes { get; set; }
        
        public virtual ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        
    }
}