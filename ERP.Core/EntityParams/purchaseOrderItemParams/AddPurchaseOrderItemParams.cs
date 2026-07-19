namespace ERP.Core.EntityParams.purchaseOrderItemParams
{
    public record AddPurchaseOrderItemParams
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
