namespace ERP.Core.EntityParams.purchaseOrderItemParams
{
    public record AddPurchaseOrderItemParams
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
