using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IPurchaseOrderRepo
    {
        Task<Result<PurchaseOrderDTO>> GetById(int Id);
        Task<Result<PagedResult<PurchaseOrderDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddPurchaseOrderParams Params);
        Task<Result<bool>> Update(int Id, UpdatePurchaseOrderParams Params);
        Task<Result<int>> Buy(BuyParams BuyParams);
    }
}
