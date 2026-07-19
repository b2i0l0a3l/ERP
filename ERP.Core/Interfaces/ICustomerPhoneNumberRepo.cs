using ERP.Core.EntityParams.customerPhoneNumberParams;
using ERP.Core.Models.CustomerPhoneNumberModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ICustomerPhoneNumberRepo
    {
        Task<Result<CustomerPhoneNumberDTO>> GetById(int Id);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddCustomerPhoneNumberParams Params);
        Task<Result<bool>> Update(int Id, UpdateCustomerPhoneNumberParams Params);
    }
}
