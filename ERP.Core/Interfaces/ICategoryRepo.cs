using ERP.Core.EntityParams.categoryParams;
using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ICategoryRepo
    {
        Task<Result<CategoryDTO>> GetById(int Id);
        Task<Result<CategoryDTO>> GetByName(string Name);
        Task<Result<PagedResult<CategoryDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddCategoryParams Params);
        Task<Result<bool>> Update(int Id, UpdateCategoryParams Params);
    }
}
