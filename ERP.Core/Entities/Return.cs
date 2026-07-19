using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.enums;

namespace ERP.Core.Entities
{
    public class Return : BaseEntity
    {
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; } = new();
        public string? Reason { get; set; }
        public enReturnStatus Status { get; set; }
        public ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();
        

    }
}