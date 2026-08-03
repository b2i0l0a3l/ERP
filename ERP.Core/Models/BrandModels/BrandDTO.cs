namespace ERP.Core.Models.BrandModels
{
    public record BrandDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; }
    }
}
