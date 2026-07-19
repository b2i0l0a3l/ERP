using ERP.Core.Entities;
using ERP.Core.EntityParams.brandParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class BrandRepo : IBrandRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<BrandRepo> _Logger;
        public BrandRepo(AppDbContext context, ILogger<BrandRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddBrandParams Params)
        {
            try
            {
                Brand brand = new()
                {
                    Name = Params.Name,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Brands.Add(brand);
                await _Context.SaveChangesAsync();
                return brand.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Brand");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Brand? brand = await _Context.Brands.FindAsync(Id);
                if (brand == null) return Errors.BrandNotFound;
                brand.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<BrandDTO>> GetById(int Id)
        {
            try
            {
                BrandDTO? brand = await _Context.Brands.AsNoTracking()
                    .Where(b => b.Id == Id && b.IsDeleted == false)
                    .Select(b => new BrandDTO() { Id = b.Id, Name = b.Name, CreatedAt = b.CreatedAt })
                    .SingleOrDefaultAsync();

                if (brand == null) return Errors.BrandNotFound;
                return brand;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<BrandDTO>> GetByName(string Name)
        {
            try
            {
                BrandDTO? brand = await _Context.Brands.AsNoTracking()
                    .Where(b => b.IsDeleted == false && b.Name == Name)
                    .Select(b => new BrandDTO() { Id = b.Id, Name = b.Name, CreatedAt = b.CreatedAt })
                    .FirstOrDefaultAsync();

                if (brand == null) return Errors.BrandNotFound;
                return brand;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<BrandDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Brand> query = _Context.Brands.AsNoTracking()
                    .Where(b => b.IsDeleted == false && (Params.Name == null || b.Name.ToLower().Contains(Params.Name.ToLower())));

                int count = await query.CountAsync();

                List<BrandDTO>? brands = await query
                    .OrderByDescending(b => b.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(b => new BrandDTO() { Id = b.Id, Name = b.Name, CreatedAt = b.CreatedAt })
                    .ToListAsync();

                return new PagedResult<BrandDTO>()
                {
                    Items = brands,
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

        public async Task<Result<bool>> Update(int Id, UpdateBrandParams Params)
        {
            try
            {
                Brand? brand = await _Context.Brands.FindAsync(Id);
                if (brand == null) return Errors.BrandNotFound;
                brand.Name = Params.Name;
                _Context.Brands.Update(brand);
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
