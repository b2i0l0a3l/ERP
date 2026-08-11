using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.InvoiceModels
{
    public class InvoiceTask
    {
        public InvoiceDTO? invoice { get; set; }
        public List<InvoiceItemDTO>? items { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}