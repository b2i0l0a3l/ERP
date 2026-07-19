using ERP.Core.EntityParams.warehouseParams;
using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IWarehouseRepo
    {
        Task<Result<WarehouseDTO>> GetById(int Id);
        Task<Result<WarehouseDTO>> GetByName(string Name);
        Task<Result<PagedResult<WarehouseDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddWarehouseParams Params);
        Task<Result<bool>> Update(int Id, UpdateWarehouseParams Params);
    }
}
