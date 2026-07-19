namespace ERP.Core.EntityParams.purchaseOrderItemParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? PurchaseOrderId { get; set; }
    }
}
