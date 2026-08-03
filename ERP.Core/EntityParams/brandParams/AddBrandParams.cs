namespace ERP.Core.EntityParams.brandParams
{
    public record AddBrandParams
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
