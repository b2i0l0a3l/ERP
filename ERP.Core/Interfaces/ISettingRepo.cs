using ERP.Core.EntityParams.settingParams;
using ERP.Core.Models.SettingModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ISettingRepo
    {
        Task<Result<SettingDTO>> GetById(int Id);
        Task<Result<SettingDTO>> GetByCompanyName(string CompanyName);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddSettingParams Params);
        Task<Result<bool>> Update(int Id, UpdateSettingParams Params);
    }
}
