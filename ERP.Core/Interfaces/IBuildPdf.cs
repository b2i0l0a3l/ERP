using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.InvoiceModels;

namespace ERP.Core.Interfaces
{
    public interface IBuildPdf
    {
        Stream BuildPdf(InvoiceDTO invoice, List<InvoiceItemDTO> items);
    }
}