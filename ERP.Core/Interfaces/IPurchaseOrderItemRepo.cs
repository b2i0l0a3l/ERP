using ERP.Core.EntityParams.purchaseOrderItemParams;
using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IPurchaseOrderItemRepo
    {
        Task<Result<PurchaseOrderItemDTO>> GetById(int Id);
        Task<Result<PagedResult<PurchaseOrderItemDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddPurchaseOrderItemParams Params);
        Task<Result<bool>> Update(int Id, UpdatePurchaseOrderItemParams Params);
        Task<Result<List<PurchaseOrderItemDTO>>> GetByPurchaseOrderId(int PurchaseOrderId);
    }
}
