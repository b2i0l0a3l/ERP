namespace ERP.Core.EntityParams.customerParams
{
    public record AddCustomerParams
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
