namespace ERP.Core.Models.ProductImageModels
{
    public record ProductImageDTO
    {
        public int Id { get; init; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
