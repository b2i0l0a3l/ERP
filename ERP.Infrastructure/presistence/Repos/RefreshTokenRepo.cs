using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using ERP.Infrastructure.presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<RefreshTokenRepo> _logger;

        public RefreshTokenRepo(AppDbContext context, ILogger<RefreshTokenRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RefreshToken?> GetByEmailAsync(string email)
        {
            return await _context.RefreshTokens
                .Where(rt => rt.User.Email == email)
                .OrderByDescending(rt => rt.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Result<bool>> AddAsync(RefreshToken refreshToken)
        {
            try
            {
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding refresh token for user {UserId}", refreshToken.UserId);
                return new Error("DatabaseError", ErrorType.General, "Failed to add refresh token.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(RefreshToken refreshToken)
        {
            try
            {
                _context.RefreshTokens.Update(refreshToken);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating refresh token for user {UserId}", refreshToken.UserId);
                return new Error("DatabaseError", ErrorType.General, "Failed to update refresh token.");
            }
        }
        public async Task<Result<bool>> RevokeRefreshTokenAsync(string UserId)
        {
            try
            {
               await _context.RefreshTokens.Where(r => r.UserId == UserId && r.RevokedAt == null)
                .ExecuteUpdateAsync(s=>s.SetProperty(r=>r.RevokedAt,DateTime.UtcNow));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating refresh token for user {UserId}", UserId);
                return new Error("DatabaseError", ErrorType.General, "Failed to update refresh token.");
            }
        }
    }
}
