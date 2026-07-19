using ERP.Core.Entities;
using ERP.Core.EntityParams.warehouseParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.WarehouseModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class WarehouseRepo : IWarehouseRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<WarehouseRepo> _Logger;
        public WarehouseRepo(AppDbContext context, ILogger<WarehouseRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddWarehouseParams Params)
        {
            try
            {
                Warehouse warehouse = new()
                {
                    Name = Params.Name,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Warehouses.Add(warehouse);
                await _Context.SaveChangesAsync();
                return warehouse.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Warehouse");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Warehouse? warehouse = await _Context.Warehouses.FindAsync(Id);
                if (warehouse == null) return Errors.WarehouseNotFound;
                warehouse.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<WarehouseDTO>> GetById(int Id)
        {
            try
            {
                WarehouseDTO? warehouse = await _Context.Warehouses.AsNoTracking()
                    .Where(w => w.Id == Id && w.IsDeleted == false)
                    .Select(w => new WarehouseDTO() { Id = w.Id, Name = w.Name, CreatedAt = w.CreatedAt })
                    .SingleOrDefaultAsync();

                if (warehouse == null) return Errors.WarehouseNotFound;
                return warehouse;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<WarehouseDTO>> GetByName(string Name)
        {
            try
            {
                WarehouseDTO? warehouse = await _Context.Warehouses.AsNoTracking()
                    .Where(w => w.IsDeleted == false && w.Name == Name)
                    .Select(w => new WarehouseDTO() { Id = w.Id, Name = w.Name, CreatedAt = w.CreatedAt })
                    .FirstOrDefaultAsync();

                if (warehouse == null) return Errors.WarehouseNotFound;
                return warehouse;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<WarehouseDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Warehouse> query = _Context.Warehouses.AsNoTracking()
                    .Where(w => w.IsDeleted == false && (Params.Name == null || w.Name.ToLower().Contains(Params.Name.ToLower())));

                int count = await query.CountAsync();

                List<WarehouseDTO>? warehouses = await query
                    .OrderByDescending(w => w.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(w => new WarehouseDTO() { Id = w.Id, Name = w.Name, CreatedAt = w.CreatedAt })
                    .ToListAsync();

                return new PagedResult<WarehouseDTO>()
                {
                    Items = warehouses,
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

        public async Task<Result<bool>> Update(int Id, UpdateWarehouseParams Params)
        {
            try
            {
                Warehouse? warehouse = await _Context.Warehouses.FindAsync(Id);
                if (warehouse == null) return Errors.WarehouseNotFound;
                warehouse.Name = Params.Name;
                _Context.Warehouses.Update(warehouse);
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
