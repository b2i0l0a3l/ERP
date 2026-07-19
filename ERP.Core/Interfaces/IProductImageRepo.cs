using ERP.Core.EntityParams.productImageParams;
using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IProductImageRepo
    {
        Task<Result<ProductImageDTO>> GetById(int Id);
        Task<Result<bool>> Delete(int Id);
        Task<Result<int>> Add(AddProductImageParams Params);
    }
}
