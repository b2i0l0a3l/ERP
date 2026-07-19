using ERP.Core.EntityParams.userParams;
using ERP.Core.Models.UserModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IUserRepo
    {
        Task<Result<UserDTO>> GetById(string Id);
        Task<Result<UserDTO>> GetByEmail(string Email);
        Task<Result<PagedResult<UserDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(string Id);
        Task<Result<string>> Add(AddUserParams Params);
        Task<Result<bool>> Update(string Id, UpdateUserParams Params);
    }
}
