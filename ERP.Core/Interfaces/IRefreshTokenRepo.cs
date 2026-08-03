using ERP.Core.Entities;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task<RefreshToken?> GetByEmailAsync(string email);
        Task<Result<bool>> AddAsync(RefreshToken refreshToken);
        Task<Result<bool>> UpdateAsync(RefreshToken refreshToken);
    }
}
