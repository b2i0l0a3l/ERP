namespace ERP.Core.Models.CustomerModels
{
    public record CustomerDTO
    {
        public int Id { get; init; }
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
