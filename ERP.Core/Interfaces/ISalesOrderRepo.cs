using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ISalesOrderRepo
    {
        Task<Result<int>> Sell(SellParams sellParams);
        Task<Result<SalesOrderDTO>> GetById(int Id);
        Task<Result<PagedResult<SalesOrderDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id, string UserId,int WarehouseId);
        Task<Result<bool>> UndoDelete(int Id,int WarehouseId);
        Task<Result<int>> Add(AddSalesOrderParams Params);
        Task<Result<bool>> Update(int Id, UpdateSalesOrderParams Params);
        Task<Result<bool>> CancelSalesOrder(int orderId, int warehouseId, string cancelledByUserId, CancellationToken cancellationToken = default);
        Task<Result<bool>> UpdateStatus(int orderId, int newStatus, CancellationToken cancellationToken = default);
    }
}
