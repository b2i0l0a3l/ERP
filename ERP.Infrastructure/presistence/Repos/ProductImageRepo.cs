using ERP.Core.Entities;
using ERP.Core.EntityParams.productImageParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.ProductImageModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class ProductImageRepo : IProductImageRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<ProductImageRepo> _Logger;
        public ProductImageRepo(AppDbContext context, ILogger<ProductImageRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddProductImageParams Params)
        {
            try
            {
                ProductImage image = new()
                {
                    ProductId = Params.ProductId,
                    ImageUrl = Params.ImageUrl,
                    CreatedAt = Params.CreatedAt
                };
                _Context.ProductImages.Add(image);
                await _Context.SaveChangesAsync();
                return image.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Product Image");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                ProductImage? image = await _Context.ProductImages.FindAsync(Id);
                if (image == null) return Errors.ProductImageNotFound;
                _Context.ProductImages.Remove(image);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<ProductImageDTO>> GetById(int Id)
        {
            try
            {
                ProductImageDTO? image = await _Context.ProductImages.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new ProductImageDTO() { Id = i.Id, ProductId = i.ProductId, ImageUrl = i.ImageUrl, CreatedAt = i.CreatedAt })
                    .SingleOrDefaultAsync();

                if (image == null) return Errors.ProductImageNotFound;
                return image;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
