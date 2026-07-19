namespace ERP.Core.Models.CategoryModels
{
    public record CategoryDTO
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
