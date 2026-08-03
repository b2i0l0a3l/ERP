namespace ERP.Core.EntityParams.settingParams
{
    public record AddSettingParams
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "USD";
        public int WarehouseId { get; set; }
        public decimal Tax { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
