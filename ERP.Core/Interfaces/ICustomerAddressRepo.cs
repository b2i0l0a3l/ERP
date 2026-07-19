using ERP.Core.EntityParams.customerAddressParams;
using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ICustomerAddressRepo
    {
        Task<Result<CustomerAddressDTO>> GetById(int Id);
        Task<Result<PagedResult<CustomerAddressDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddCustomerAddressParams Params);
        Task<Result<bool>> Update(int Id, UpdateCustomerAddressParams Params);
    }
}
