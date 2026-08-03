namespace ERP.Core.EntityParams.invoiceItemParams
{
    public record AddInvoiceItemParams
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal LineTotal { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
