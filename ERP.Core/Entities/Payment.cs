using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class Payment : BaseEntity
    {
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public string? ReferenceNumber { get; set; }

        public enPaymentMethod PaymentMethod { get; set; } = enPaymentMethod.Cash;
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public virtual SalesOrder? SalesOrder { get; set; }
    }
}