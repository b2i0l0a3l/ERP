namespace ERP.Core.Models.InventoryModels
{
    public record InventoryDTO
    {
        public int Id { get; init; }
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int MinThreshold { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
