using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class SalesOrder : BaseEntity
    {
        public int? CustomerId { get; set; }
        public decimal Total { get; set; }

        public decimal PaidAmount { get; set; }
        public decimal RemainingBalance => Total - PaidAmount;
        public bool IsFullyPaid => RemainingBalance <= 0;
        public bool IsCredit => PaidAmount < Total;
        public enPaymentStatus PaymentStatus { get; set; } = enPaymentStatus.Unpaid;
        public enStatus Status { get; set; } = enStatus.Pending;
        public decimal Discount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
        public virtual ICollection<Return> Returns { get; set; } = new List<Return>();
    }
}