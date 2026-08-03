using ERP.Core.Entities;

namespace ERP.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, IList<string> roles);
        string GenerateRefreshToken();
    }
}
