using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class RoleRepo : IRoleRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleRepo> _logger;

        public RoleRepo(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<RoleRepo> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<Result<bool>> AssignRoleAsync(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return Errors.UserNotFound;

                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                    return Errors.RoleNotFound;

                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                {
                    var errorDescription = string.Join("; ", result.Errors.Select(e => e.Description));
                    return new Error("AssignRoleFailed", ErrorType.General, errorDescription);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning role {RoleName} to user {UserId}", roleName, userId);
                return new Error("AssignRoleFailed", ErrorType.General, "An error occurred while assigning role.");
            }
        }
    }
}
