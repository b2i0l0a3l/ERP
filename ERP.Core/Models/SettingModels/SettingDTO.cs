namespace ERP.Core.Models.SettingModels
{
    public record SettingDTO
    {
        public int Id { get; init; }
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "USD";
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public decimal Tax { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
