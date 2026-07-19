using ERP.Core.Entities;
using ERP.Core.EntityParams.settingParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SettingModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class SettingRepo : ISettingRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<SettingRepo> _Logger;
        public SettingRepo(AppDbContext context, ILogger<SettingRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddSettingParams Params)
        {
            try
            {
                Setting setting = new()
                {
                    CompanyName = Params.CompanyName,
                    LogoUrl = Params.LogoUrl,
                    Currency = Params.Currency,
                    WarehouseId = Params.WarehouseId,
                    Tax = Params.Tax,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Settings.Add(setting);
                await _Context.SaveChangesAsync();
                return setting.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Setting");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Setting? setting = await _Context.Settings.FindAsync(Id);
                if (setting == null) return Errors.SettingNotFound;
                setting.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<SettingDTO>> GetById(int Id)
        {
            try
            {
                SettingDTO? setting = await _Context.Settings.AsNoTracking()
                    .Where(s => s.Id == Id && s.IsDeleted == false)
                    .Select(s => new SettingDTO() { Id = s.Id, CompanyName = s.CompanyName, LogoUrl = s.LogoUrl, Currency = s.Currency, WarehouseId = s.WarehouseId, WarehouseName = s.Warehouse.Name, Tax = s.Tax, CreatedAt = s.CreatedAt })
                    .SingleOrDefaultAsync();

                if (setting == null) return Errors.SettingNotFound;
                return setting;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<SettingDTO>> GetByCompanyName(string CompanyName)
        {
            try
            {
                SettingDTO? setting = await _Context.Settings.AsNoTracking()
                    .Where(s => s.IsDeleted == false && s.CompanyName == CompanyName)
                    .Select(s => new SettingDTO() { Id = s.Id, CompanyName = s.CompanyName, LogoUrl = s.LogoUrl, Currency = s.Currency, WarehouseId = s.WarehouseId, WarehouseName = s.Warehouse.Name, Tax = s.Tax, CreatedAt = s.CreatedAt })
                    .FirstOrDefaultAsync();

                if (setting == null) return Errors.SettingNotFound;
                return setting;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(int Id, UpdateSettingParams Params)
        {
            try
            {
                Setting? setting = await _Context.Settings.FindAsync(Id);
                if (setting == null) return Errors.SettingNotFound;
                setting.CompanyName = Params.CompanyName;
                setting.LogoUrl = Params.LogoUrl;
                setting.Currency = Params.Currency;
                setting.WarehouseId = Params.WarehouseId;
                setting.Tax = Params.Tax;
                _Context.Settings.Update(setting);
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
