using ERP.Core.EntityParams.invoiceItemParams;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IInvoiceItemRepo
    {
        Task<Result<InvoiceItemDTO>> GetById(int Id);
        Task<Result<PagedResult<InvoiceItemDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<List<InvoiceItemDTO>>> GetByInvoiceId(int InvoiceId);
        Task<Result<PagedResult<InvoiceItemDTO>>> GetByInvoiceId(int InvoiceId, int PageNumber, int PageSize);
    }
}
