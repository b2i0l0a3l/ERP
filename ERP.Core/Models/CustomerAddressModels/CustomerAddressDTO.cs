namespace ERP.Core.Models.CustomerAddressModels
{
    public record CustomerAddressDTO
    {
        public int Id { get; init; }
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
