using System.Data;
using ERP.Core.Entities;
using ERP.Core.EntityParams.productParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<ProductRepo> _Logger;
        public ProductRepo( AppDbContext context, ILogger<ProductRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }
        public async Task<Result<int>> Add(AddProductParams Params)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_AddNewProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BrandId", Params.BrandId);
                    command.Parameters.AddWithValue("@CategoryId", Params.CategoryId);
                    command.Parameters.AddWithValue("@Description", Params.Description);
                    command.Parameters.AddWithValue("@CreatedByUserId", Params.CreatedByUserId );
                    command.Parameters.AddWithValue("@Name", Params.Name);
                    command.Parameters.AddWithValue("@CostPrice", Params.CostPrice);
                    command.Parameters.AddWithValue("@SellingPrice", Params.SellingPrice);
                    command.Parameters.AddWithValue("@SKU", Params.SKU );
                    command.Parameters.AddWithValue("@Barcode", Params.Barcode );

                    DataTable? ItemsDataTable = ConvertToDataTable(Params.ImageUrl!);
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@ImageUrl", ItemsDataTable );
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.ProductImages";

                    SqlParameter outputIdParam = new SqlParameter("@ProductId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    await command.ExecuteNonQueryAsync();
                    if (outputIdParam.Value == DBNull.Value)
                    {
                        return new Error("Product", ErrorType.General, "Something Went Wrong!");
                    }
                    return (int)outputIdParam.Value;

                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_RemoveProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", Id);

                    int affectedRows = await command.ExecuteNonQueryAsync();

                    return affectedRows != -1;

                }


            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }

        public async Task<Result<ProductDTO>> GetByBarcode(string Barcode)
        {
            try
            {
                ProductDTO? product = await _Context.Products.AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Barcode == Barcode)
                .Select(p => new ProductDTO() { Barcode = Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null })
                .SingleOrDefaultAsync();

                if (product == null) return Errors.ProductNotFound;

                return product;

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<ProductDTO>> GetById(int Id)
        {
            try
            {
                ProductDTO? product = await _Context.Products.AsNoTracking()
                .Where(p => p.Id == Id && p.IsDeleted == false)
                .Select(p => new ProductDTO() {Id = p.Id , Name=p.Name ,  Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null })
                .SingleOrDefaultAsync();

                if (product == null) return Errors.ProductNotFound;

                return product;

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<ProductDTO>> GetByName(string Name)
        {
            try
            {
                ProductDTO? product = await _Context.Products.AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Name == Name)
                .Select(p => new ProductDTO() { Id = p.Id , Name=p.Name, Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null })
                .FirstOrDefaultAsync();

                if (product == null) return Errors.ProductNotFound;

                return product;

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<ProductDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Product> query = _Context.Products
                .AsNoTracking()
                .Where(p => p.IsDeleted == false && (Params.BarCode == null || Params.BarCode == p.Barcode) && (Params.ProductName == null || p.Name.ToLower().Contains(Params.ProductName.ToLower())));

                int count = await query.CountAsync();

                List<ProductDTO>? products = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((Params.PageNumber - 1) * Params.PageSize)
                .Take(Params.PageSize)
                .Select(p => new ProductDTO() {Id = p.Id , Name=p.Name, Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null })
                .ToListAsync();

                PagedResult<ProductDTO> result = new()
                {
                    Items = products,
                    PageNumber = Params.PageNumber,
                    PageSize = Params.PageSize,
                    TotalCount = count
                };
                return result;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(int Id, UpdateProductParams Params)
        {
            try
            {
                Product? product = await _Context.Products.FindAsync(Id);
                if (product == null) return Errors.ProductNotFound;
                product.Name = Params.Name;
                if (!string.IsNullOrEmpty(Params.SKU)) product.SKU = Params.SKU;
                if (!string.IsNullOrEmpty(Params.Description)) product.Description = Params.Description;
                if (!string.IsNullOrEmpty(Params.Barcode)) product.Barcode = Params.Barcode;
                product.CostPrice = Params.CostPrice;
                product.SellingPrice = Params.SellingPrice;
                if (Params.BrandId.HasValue && Params.BrandId.Value > 0) product.BrandId = Params.BrandId;

                _Context.Products.Update(product);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }
        public async Task<Result<PagedResult<ProductDTO>>> Search(string Query, int PageNumber, int PageSize)
        {
            try
            {
                IQueryable<Product> query = _Context.Products
                    .AsNoTracking()
                    .Where(p => p.IsDeleted == false && (p.Name.ToLower().Contains(Query.ToLower()) || (p.Barcode != null && p.Barcode.Contains(Query)) || (p.SKU != null && p.SKU.ToLower().Contains(Query.ToLower()))));

                int count = await query.CountAsync();

                List<ProductDTO>? products = await query
                    .OrderByDescending(x => x.CreatedAt)
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .Select(p => new ProductDTO() {Id = p.Id , Name=p.Name, Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null })
                    .ToListAsync();

                return new PagedResult<ProductDTO>()
                {
                    Items = products,
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                    TotalCount = count
                };
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<ProductDTO>>> GetProductByCategory(int CategoryId, int PageNumber, int PageSize)
        {
            try
            {
                IQueryable<Product> query = _Context.Products
                  .AsNoTracking()
                  .Where(p => p.IsDeleted == false && p.CategoryId == CategoryId);

                int count = await query.CountAsync();

                List<ProductDTO> products = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new ProductDTO() { Id = p.Id , Name=p.Name,Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null }).ToListAsync();

                return new PagedResult<ProductDTO>()
                {
                    Items = products,
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                    TotalCount = count
                };

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
          public async Task<Result<PagedResult<ProductDTO>>> GetProductByBrand(int BrandId,int PageNumber , int PageSize)
        {
            try
            {
                IQueryable<Product> query = _Context.Products
                  .AsNoTracking()
                  .Where(p => p.IsDeleted == false && p.BrandId == BrandId);

                int count = await query.CountAsync();

                List<ProductDTO> products = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new ProductDTO() {Id = p.Id , Name=p.Name, Barcode = p.Barcode, CostPrice = p.CostPrice, SellingPrice = p.SellingPrice, SKU = p.SKU, Brand = p.Brand != null ? p.Brand.Name : null, ImageUrl = p.ProductImages.Select(img => img.ImageUrl).ToList(), Category = p.Category.Name, CreatedAt = p.CreatedAt, CreatedByUser = p.CreatedByUser != null ? p.CreatedByUser.FirstName : null }).ToListAsync();

                return new PagedResult<ProductDTO>()
                {
                    Items = products,
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                    TotalCount = count
                };
           
            }catch(Exception ex)
            {
                 _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");                
            }
        }
        private DataTable? ConvertToDataTable(List<string> Images)
        {
            if (Images.Count <= 0 || Images == null)
            {
                return null;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Images", typeof(string));

            foreach (var img in Images)
            {
                table.Rows.Add(img);
            }
            return table;
        }
    }

}