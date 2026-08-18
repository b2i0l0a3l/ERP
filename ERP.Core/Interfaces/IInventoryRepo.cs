using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IInventoryRepo
    {
        Task<Result<InventoryDTO>> GetById(int Id);
        Task<Result<InventoryDTO>> GetByProductId(int ProductId);
        Task<Result<PagedResult<InventoryDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddInventoryParams Params);
        Task<Result<bool>> Update(int Id, UpdateInventoryParams Params);
        Task<Result<bool>> TransferStock(int fromWarehouseId, int toWarehouseId, int productId, int quantity, string adjustedByUserId, string? reason = null, CancellationToken cancellationToken = default);
        Task<Result<bool>> AdjustInventory(int warehouseId, int productId, int newQuantity, string adjustedByUserId, string reason, CancellationToken cancellationToken = default);
    }
}
