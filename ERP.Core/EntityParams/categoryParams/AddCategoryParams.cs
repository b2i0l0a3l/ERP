namespace ERP.Core.EntityParams.categoryParams
{
    public record AddCategoryParams
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
