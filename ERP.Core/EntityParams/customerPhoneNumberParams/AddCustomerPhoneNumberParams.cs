namespace ERP.Core.EntityParams.customerPhoneNumberParams
{
    public record AddCustomerPhoneNumberParams
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
