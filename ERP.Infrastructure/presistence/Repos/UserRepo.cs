using ERP.Core.Entities;
using ERP.Core.EntityParams.userParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.UserModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<UserRepo> _Logger;
        public UserRepo(AppDbContext context, ILogger<UserRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }


        public async Task<Result<bool>> Delete(string Id)
        {
            try
            {
                User? user = await _Context.Users.FindAsync(Id);
                if (user == null) return Errors.UserNotFound;
                _Context.Users.Remove(user);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<UserDTO>> GetById(string Id)
        {
            try
            {
                UserDTO? user = await _Context.Users.AsNoTracking()
                    .Where(u => u.Id == Id == false)
                    .Select(u => new UserDTO() { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email ?? "N/A", PhoneNumber = u.PhoneNumber ?? "N/A", IsActive = u.IsActive })
                    .SingleOrDefaultAsync();

                if (user == null) return Errors.UserNotFound;
                return user;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<UserDTO>> GetByEmail(string Email)
        {
            try
            {
                UserDTO? user = await _Context.Users.AsNoTracking()
                    .Select(u => new UserDTO() { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email ?? "N/A", PhoneNumber = u.PhoneNumber ?? "N/A", IsActive = u.IsActive })
                    .FirstOrDefaultAsync(u => u.Email == Email);

                if (user == null) return Errors.UserNotFound;
                return user;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<UserDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<User> query = _Context.Users.AsNoTracking()
                    .Where(u => Params.Name == null || u.FirstName.ToLower().Contains(Params.Name.ToLower()) || u.LastName.ToLower().Contains(Params.Name.ToLower()));

                int count = await query.CountAsync();

                List<UserDTO>? users = await query
                    .OrderBy(u => u.FirstName)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(u => new UserDTO() { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email ?? "N/A", PhoneNumber = u.PhoneNumber ?? "N/A", IsActive = u.IsActive })
                    .ToListAsync();

                return new PagedResult<UserDTO>()
                {
                    Items = users,
                    PageNumber = Params.PageNumber,
                    PageSize = Params.PageSize,
                    TotalCount = count
                };
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(string Id, UpdateUserParams Params)
        {
            try
            {
                User? user = await _Context.Users.FindAsync(Id);
                if (user == null) return Errors.UserNotFound;
                user.FirstName = Params.FirstName;
                user.LastName = Params.LastName;
                user.Email = Params.Email;
                user.PhoneNumber = Params.PhoneNumber;
                user.IsActive = Params.IsActive;
                _Context.Users.Update(user);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
