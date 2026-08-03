using ERP.Core.EntityParams.AuthParams.Login;
using ERP.Core.EntityParams.AuthParams.RefreshToken;
using ERP.Core.Models.AuthModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> LoginAsync(LoginRequest request);
        Task<Result<RegisterResponse>> RegisterAsync(string firstName, string lastName, string email, string password, string? phoneNumber);
        Task<Result<AuthResponse>> RefreshTokenAsync(RefreshTokenRequest request);
        Task<Result<bool>> Logout(RefreshTokenRequest request);
    }
}