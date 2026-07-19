namespace ERP.Core.Models.SalesOrderItemModels
{
    public record SalesOrderItemDTO
    {
        public int Id { get; init; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
