namespace ERP.Core.Models.UserModels
{
    public record UserDTO
    {
        public string Id { get; init; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
