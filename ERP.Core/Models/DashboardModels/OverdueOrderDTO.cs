namespace ERP.Core.Models.DashboardModels
{
    public class OverdueOrderDTO
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}
