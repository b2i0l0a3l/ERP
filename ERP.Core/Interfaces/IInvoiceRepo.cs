using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IInvoiceRepo
    {
        Task<Result<InvoiceDTO>> GetById(int Id);
        Task<Result<PagedResult<InvoiceDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddInvoiceParams Params);
        Task<Result<bool>> Update(int Id, UpdateInvoiceParams Params);
        Task<Result<int>> CreateCompleteInvoice(CreateCompleteInvoiceParams Params);
    }
}
