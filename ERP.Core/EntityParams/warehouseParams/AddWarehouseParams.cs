namespace ERP.Core.EntityParams.warehouseParams
{
    public record AddWarehouseParams
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
