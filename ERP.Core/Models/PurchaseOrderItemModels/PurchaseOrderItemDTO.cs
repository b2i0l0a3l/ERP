namespace ERP.Core.Models.PurchaseOrderItemModels
{
    public record PurchaseOrderItemDTO
    {
        public int Id { get; init; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
