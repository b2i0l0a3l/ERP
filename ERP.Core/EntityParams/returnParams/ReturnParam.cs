using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.EntityParams.returnParams
{
    public class ReturnParam
    {
        public int WarehouseId { get; set; }
        public int SaleOrderId { get; set; }
        public string? Reason { get; set; }
        public enReturnStatus Status { get; set; }
        public string? CreatedByUserId { get; set; }
        public List<ReturnItemParam> Items { get; set; } = new List<ReturnItemParam>();

    }
    public record ReturnItemParam
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal RefundAmount { get; set; }
        public enReturnItemCondition Condition { get; set; }
        
    }
}