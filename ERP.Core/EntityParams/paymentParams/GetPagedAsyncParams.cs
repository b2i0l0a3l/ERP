namespace ERP.Core.EntityParams.paymentParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? SaleOrderId { get; set; }
        public int? PurchaseOrderId { get; set; }
    }
}
