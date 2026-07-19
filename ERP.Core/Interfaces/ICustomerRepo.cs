using ERP.Core.EntityParams.customerParams;
using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface ICustomerRepo
    {
        Task<Result<CustomerDTO>> GetById(int Id);
        Task<Result<PagedResult<CustomerDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddCustomerParams Params);
        Task<Result<bool>> Update(int Id, UpdateCustomerParams Params);
        Task<Result<decimal>> GetCustomerBalance(int CustomerId);
    }
}
