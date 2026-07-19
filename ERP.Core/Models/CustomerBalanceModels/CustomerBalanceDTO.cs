namespace ERP.Core.Models.CustomerBalanceModels
{
    public record CustomerBalanceDTO
    {
        public int CustomerId { get; init; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
