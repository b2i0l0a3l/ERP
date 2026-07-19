namespace ERP.Core.EntityParams.settingParams
{
    public class UpdateSettingParams
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Currency { get; set; } = "USD";
        public int WarehouseId { get; set; }
        public decimal Tax { get; set; }
    }
}
