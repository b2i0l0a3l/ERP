namespace ERP.Core.EntityParams.customerPhoneNumberParams
{
    public record AddCustomerPhoneNumberParams
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
