namespace ERP.Core.EntityParams.categoryParams
{
    public record AddCategoryParams
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
