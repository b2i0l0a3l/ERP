using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class ReturnItem : BaseEntity
    {
        public int ReturnId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
        public decimal RefundAmount { get; set; }
        public enReturnItemCondition Condition { get; set; }
    }
}