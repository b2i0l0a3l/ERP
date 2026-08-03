using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IRoleRepo
    {
        Task<Result<bool>> AssignRoleAsync(string userId, string roleName);
    }
}
