namespace ERP.Core.EntityParams.productImageParams
{
    public record AddProductImageParams
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
