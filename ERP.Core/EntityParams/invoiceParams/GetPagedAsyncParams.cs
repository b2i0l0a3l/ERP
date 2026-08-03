using ERP.Core.enums;

namespace ERP.Core.EntityParams.invoiceParams
{
    public record GetPagedAsyncParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public enInvoiceStatus? Status { get; set; }
        public enInvoiceType? Type { get; set; }
    }
}
