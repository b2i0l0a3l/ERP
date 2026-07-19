using ERP.Core.EntityParams.salesOrderItemParams;
using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ISalesOrderItemRepo
    {
        Task<Result<SalesOrderItemDTO>> GetById(int Id);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddSalesOrderItemParams Params);
        Task<Result<bool>> Update(int Id, UpdateSalesOrderItemParams Params);
        Task<Result<List<SalesOrderItemDTO>>> GetBySalesOrderId(int SalesOrderId);
    }
}
