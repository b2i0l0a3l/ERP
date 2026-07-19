using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public int SupplierId { get; set; }
        public enStatus OrderStatus { get; set; } = enStatus.Pending;
        public enPaymentStatus PaymentStatus { get; set; } = enPaymentStatus.Unpaid;
        public decimal Total { get; set; }
        public virtual Supplier Supplier { get; set; } = new();
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        
    }
}