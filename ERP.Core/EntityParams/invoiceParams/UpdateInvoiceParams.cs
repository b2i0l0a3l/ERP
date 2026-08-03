using ERP.Core.enums;

namespace ERP.Core.EntityParams.invoiceParams
{
    public class UpdateInvoiceParams
    {
        public enInvoiceStatus Status { get; set; } = enInvoiceStatus.Draft;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
    }
}
