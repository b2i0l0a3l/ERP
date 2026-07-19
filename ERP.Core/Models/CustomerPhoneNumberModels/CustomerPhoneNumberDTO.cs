namespace ERP.Core.Models.CustomerPhoneNumberModels
{
    public record CustomerPhoneNumberDTO
    {
        public int Id { get; init; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
