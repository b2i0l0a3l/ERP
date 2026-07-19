namespace ERP.Core.EntityParams.inventoryParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
    }
}
