namespace ERP.Core.EntityParams.brandParams
{
    public record AddBrandParams
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
