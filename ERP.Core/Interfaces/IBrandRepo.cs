using ERP.Core.EntityParams.brandParams;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IBrandRepo
    {
        Task<Result<BrandDTO>> GetById(int Id);
        Task<Result<BrandDTO>> GetByName(string Name);
        Task<Result<PagedResult<BrandDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddBrandParams Params);
        Task<Result<bool>> Update(int Id, UpdateBrandParams Params);
    }
}
