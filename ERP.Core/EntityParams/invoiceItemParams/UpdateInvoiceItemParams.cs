namespace ERP.Core.EntityParams.invoiceItemParams
{
    public class UpdateInvoiceItemParams
    {
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal LineTotal { get; set; }
    }
}
