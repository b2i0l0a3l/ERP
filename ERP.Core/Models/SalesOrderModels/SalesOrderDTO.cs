using ERP.Core.enums;

namespace ERP.Core.Models.SalesOrderModels
{
    public record SalesOrderDTO
    {
        public int Id { get; init; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public enStatus Status { get; set; }
        public enPaymentStatus PaymentStatus { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
