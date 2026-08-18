using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;

namespace ERP.Core.Interfaces
{
    public interface IProductRepo
    {
        Task<Result<PagedResult<ProductDTO>>> GetProductByBrand(int BrandId, int PageNumber, int PageSize);
        Task<Result<PagedResult<ProductDTO>>> GetProductByCategory(int CategoryId, int PageNumber, int PageSize);
        Task<Result<ProductDTO>> GetById(int Id);
        Task<Result<ProductDTO>> GetByBarcode(string Barcode);
        Task<Result<ProductDTO>> GetByName(string Name);
        Task<Result<PagedResult<ProductDTO>>> GetPaged(GetPagedAsyncParams Params);
        Task<Result<bool>> Delete(int Id, string? DeletedByUserId, CancellationToken cancellationToken = default);
        Task<Result<int>> Add(AddProductParams Params, CancellationToken cancellationToken = default);
        Task<Result<bool>> Update(int Id, UpdateProductParams Params);
        Task<Result<PagedResult<ProductDTO>>> Search(string Query, int PageNumber, int PageSize);
        Task<Result<bool>> BulkUpdatePrices(int? categoryId, int? brandId, decimal percentage, bool updateCostPrice, CancellationToken cancellationToken = default);
    }
}