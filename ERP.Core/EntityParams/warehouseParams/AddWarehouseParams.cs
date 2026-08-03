namespace ERP.Core.EntityParams.warehouseParams
{
    public record AddWarehouseParams
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
