using ERP.Core.Entities;
using ERP.Core.EntityParams.AuthParams.Login;
using ERP.Core.EntityParams.AuthParams.RefreshToken;
using ERP.Core.Interfaces;
using ERP.Core.Models.AuthModels;
using ERP.Core.shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.Shared
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            UserManager<User> userManager,
            ITokenService tokenService,
            IRefreshTokenRepo refreshTokenRepo,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenRepo = refreshTokenRepo;
            _logger = logger;
        }

        public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    return Errors.InvalidCredentials;

                if (!user.IsActive)
                    return Errors.AccountDeactivated;

                var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isValidPassword)
                    return Errors.InvalidCredentials;

                return await GenerateAuthResponseAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for {Email}", request.Email);
                return new Error("LoginFailed", ErrorType.General, "An error occurred during login.");
            }
        }

        public async Task<Result<RegisterResponse>> RegisterAsync(
            string firstName, string lastName, string email, string password, string? phoneNumber)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                    return Errors.EmailAlreadyExists;

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phoneNumber,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    var errorDescription = string.Join("; ", result.Errors.Select(e => e.Description));
                    return new Error("RegistrationFailed", ErrorType.Validation, errorDescription);
                }

                await _userManager.AddToRoleAsync(user, AppRoles.Cashier);

                return new RegisterResponse()
                {
                    UserId = user.Id,
                    Email = email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for {Email}", email);
                return new Error("RegistrationFailed", ErrorType.General, "An error occurred during registration.");
            }
        }

        public async Task<Result<AuthResponse>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            try
            {
                var refreshToken = await _refreshTokenRepo.GetByEmailAsync(request.Email);
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (refreshToken == null)
                    return new Error("RefreshTokenNotFound", ErrorType.NotFound, "Refresh Token not found!");
                if (user == null)
                    return Errors.UserNotFound;

                if (refreshToken.RevokedAt != null)
                    return Errors.RefreshtokenRevoked;
                if (refreshToken.ExpiresAt == null || refreshToken.ExpiresAt <= DateTime.UtcNow)
                    return Errors.RefreshTokenExpired;

                bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, refreshToken.Token);
                if (!refreshValid)
                    return Errors.InvalidToken;

                refreshToken.RevokedAt = DateTime.UtcNow;
                await _refreshTokenRepo.UpdateAsync(refreshToken);
                return await GenerateAuthResponseAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh");
                return new Error("RefreshFailed", ErrorType.General, "An error occurred during token refresh.");
            }
        }

        public async Task<Result<bool>> Logout(RefreshTokenRequest request)
        {
            try
            {
                var refresh = await _refreshTokenRepo.GetByEmailAsync(request.Email);

                if (refresh == null) return Errors.UserNotFound;
                bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, refresh.Token);
                if (!refreshValid) return false;

                refresh.RevokedAt = DateTime.UtcNow;
                await _refreshTokenRepo.UpdateAsync(refresh);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error revoking refresh tokens for user {Email}", request.Email);
                return new Error("RevokeFailed", ErrorType.General, "An error occurred while revoking tokens.");
            }
        }

        private async Task<string> generateRefreshTokenAndStoreIt(User user)
        {
            string refreshToken = _tokenService.GenerateRefreshToken();
            var newRefreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = BCrypt.Net.BCrypt.HashPassword(refreshToken),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                RevokedAt = null
            };
            await _refreshTokenRepo.AddAsync(newRefreshToken);
            return refreshToken;

        }
        private async Task<AuthResponse> GenerateAuthResponseAsync(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            string accessToken = _tokenService.GenerateAccessToken(user, roles);
            string refreshToken = await generateRefreshTokenAndStoreIt(user);

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
