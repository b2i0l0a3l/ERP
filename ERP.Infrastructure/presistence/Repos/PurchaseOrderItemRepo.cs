using ERP.Core.Entities;
using ERP.Core.EntityParams.purchaseOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderItemModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class PurchaseOrderItemRepo : IPurchaseOrderItemRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<PurchaseOrderItemRepo> _Logger;
        public PurchaseOrderItemRepo(AppDbContext context, ILogger<PurchaseOrderItemRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddPurchaseOrderItemParams Params)
        {
            try
            {
                PurchaseOrderItem item = new()
                {
                    PurchaseOrderId = Params.PurchaseOrderId,
                    ProductId = Params.ProductId,
                    Quantity = Params.Quantity,
                    Price = Params.Price,
                    CreatedAt = Params.CreatedAt
                };
                _Context.PurchaseOrderItems.Add(item);
                await _Context.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Purchase Order Item");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                PurchaseOrderItem? item = await _Context.PurchaseOrderItems.FindAsync(Id);
                if (item == null) return Errors.PurchaseOrderItemNotFound;
                item.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PurchaseOrderItemDTO>> GetById(int Id)
        {
            try
            {
                PurchaseOrderItemDTO? item = await _Context.PurchaseOrderItems.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new PurchaseOrderItemDTO() { Id = i.Id, PurchaseOrderId = i.PurchaseOrderId, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, Price = i.Price, CreatedAt = i.CreatedAt })
                    .SingleOrDefaultAsync();

                if (item == null) return Errors.PurchaseOrderItemNotFound;
                return item;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<PurchaseOrderItemDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<PurchaseOrderItem> query = _Context.PurchaseOrderItems.AsNoTracking()
                    .Where(i => i.IsDeleted == false && (Params.PurchaseOrderId == null || i.PurchaseOrderId == Params.PurchaseOrderId));

                int count = await query.CountAsync();

                List<PurchaseOrderItemDTO>? items = await query
                    .OrderByDescending(i => i.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(i => new PurchaseOrderItemDTO() { Id = i.Id, PurchaseOrderId = i.PurchaseOrderId, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, Price = i.Price, CreatedAt = i.CreatedAt })
                    .ToListAsync();

                return new PagedResult<PurchaseOrderItemDTO>()
                {
                    Items = items,
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

        public async Task<Result<bool>> Update(int Id, UpdatePurchaseOrderItemParams Params)
        {
            try
            {
                PurchaseOrderItem? item = await _Context.PurchaseOrderItems.FindAsync(Id);
                if (item == null) return Errors.PurchaseOrderItemNotFound;
                item.Quantity = Params.Quantity;
                item.Price = Params.Price;
                _Context.PurchaseOrderItems.Update(item);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<List<PurchaseOrderItemDTO>>> GetByPurchaseOrderId(int PurchaseOrderId)
        {
            try
            {
                List<PurchaseOrderItemDTO> items = await _Context.PurchaseOrderItems.AsNoTracking()
                    .Where(i => i.PurchaseOrderId == PurchaseOrderId && i.IsDeleted == false)
                    .Select(i => new PurchaseOrderItemDTO() { Id = i.Id, PurchaseOrderId = i.PurchaseOrderId, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, Price = i.Price, CreatedAt = i.CreatedAt })
                    .ToListAsync();

                return items;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
