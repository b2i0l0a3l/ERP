namespace ERP.Core.EntityParams.customerAddressParams
{
    public record AddCustomerAddressParams
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
