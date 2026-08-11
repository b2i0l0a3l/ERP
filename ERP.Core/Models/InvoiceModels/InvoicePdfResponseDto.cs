using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Models.InvoiceModels
{
    public record InvoicePdfResponseDto
    {
        public bool IsReady { get; set; }
        public Stream? PdfBytes { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}