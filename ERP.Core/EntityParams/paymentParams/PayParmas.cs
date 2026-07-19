using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.EntityParams.paymentParams
{
    public class PayParmas
    {
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public enPaymentMethod PaymentMethod { get; set; } = enPaymentMethod.Cash;
        public string? Notes { get; set; }
        public string CreatedByUserId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? ReferenceNumber { get; set; }
    }
}