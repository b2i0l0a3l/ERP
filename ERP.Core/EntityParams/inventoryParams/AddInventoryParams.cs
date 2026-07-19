namespace ERP.Core.EntityParams.inventoryParams
{
    public record AddInventoryParams
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
