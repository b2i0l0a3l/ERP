namespace ERP.Core.Models.SupplierBalanceModels
{
    public record SupplierBalanceDTO
    {
        public int SupplierId { get; init; }
        public string SupplierName { get; set; } = string.Empty;
        public decimal TotalPurchases { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
    }
}
