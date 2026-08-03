namespace ERP.Core.Models.WarehouseModels
{
    public record WarehouseDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
    }
}
