using ERP.Core.EntityParams.supplierParams;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ISupplierRepo
    {
        Task<Result<SupplierDTO>> GetById(int Id);
        Task<Result<SupplierDTO>> GetByName(string Name);
        Task<Result<PagedResult<SupplierDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddSupplierParams Params);
        Task<Result<bool>> Update(int Id, UpdateSupplierParams Params);
    }
}
