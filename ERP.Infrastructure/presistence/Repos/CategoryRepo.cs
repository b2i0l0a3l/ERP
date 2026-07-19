using ERP.Core.Entities;
using ERP.Core.EntityParams.categoryParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CategoryModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<CategoryRepo> _Logger;
        public CategoryRepo(AppDbContext context, ILogger<CategoryRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddCategoryParams Params)
        {
            try
            {
                Category category = new()
                {
                    Name = Params.Name,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Categories.Add(category);
                await _Context.SaveChangesAsync();
                return category.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Category");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Category? category = await _Context.Categories.FindAsync(Id);
                if (category == null) return Errors.CategoryNotFound;
                category.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<CategoryDTO>> GetById(int Id)
        {
            try
            {
                CategoryDTO? category = await _Context.Categories.AsNoTracking()
                    .Where(c => c.Id == Id && c.IsDeleted == false)
                    .Select(c => new CategoryDTO() { Id = c.Id, Name = c.Name, CreatedAt = c.CreatedAt })
                    .SingleOrDefaultAsync();

                if (category == null) return Errors.CategoryNotFound;
                return category;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<CategoryDTO>> GetByName(string Name)
        {
            try
            {
                CategoryDTO? category = await _Context.Categories.AsNoTracking()
                    .Where(c => c.IsDeleted == false && c.Name == Name)
                    .Select(c => new CategoryDTO() { Id = c.Id, Name = c.Name, CreatedAt = c.CreatedAt })
                    .FirstOrDefaultAsync();

                if (category == null) return Errors.CategoryNotFound;
                return category;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<CategoryDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Category> query = _Context.Categories.AsNoTracking()
                    .Where(c => c.IsDeleted == false && (Params.Name == null || c.Name.ToLower().Contains(Params.Name.ToLower())));

                int count = await query.CountAsync();

                List<CategoryDTO>? categories = await query
                    .OrderByDescending(c => c.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(c => new CategoryDTO() { Id = c.Id, Name = c.Name, CreatedAt = c.CreatedAt })
                    .ToListAsync();

                return new PagedResult<CategoryDTO>()
                {
                    Items = categories,
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

        public async Task<Result<bool>> Update(int Id, UpdateCategoryParams Params)
        {
            try
            {
                Category? category = await _Context.Categories.FindAsync(Id);
                if (category == null) return Errors.CategoryNotFound;
                category.Name = Params.Name;
                _Context.Categories.Update(category);
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
