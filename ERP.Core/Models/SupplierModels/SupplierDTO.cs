namespace ERP.Core.Models.SupplierModels
{
    public record SupplierDTO
    {
        public int Id { get; init; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
