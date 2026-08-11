using System.Data;
using ERP.Core.Entities;
using ERP.Core.EntityParams.salesOrderItemParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderItemModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class SalesOrderItemRepo : ISalesOrderItemRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<SalesOrderItemRepo> _Logger;
        public SalesOrderItemRepo(AppDbContext context, ILogger<SalesOrderItemRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddSalesOrderItemParams Params)
        {
            try
            {
                SalesOrderItem item = new()
                {
                    SalesOrderId = Params.SalesOrderId,
                    ProductId = Params.ProductId,
                    Quantity = Params.Quantity,
                    SellingPrice = Params.SellingPrice,
                    Discount = Params.Discount,
                    Total = Params.Total,
                    CreatedAt = Params.CreatedAt
                };
                _Context.SalesOrderItems.Add(item);
                await _Context.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Sales Order Item");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                SalesOrderItem? item = await _Context.SalesOrderItems.FindAsync(Id);
                if (item == null) return Errors.SalesOrderItemNotFound;
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

        public async Task<Result<SalesOrderItemDTO>> GetById(int Id)
        {
            try
            {
                SalesOrderItemDTO? item = await _Context.SalesOrderItems.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new SalesOrderItemDTO() { Id = i.Id, SalesOrderId = i.SalesOrderId, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, SellingPrice = i.SellingPrice, Discount = i.Discount, Total = i.Total, CreatedAt = i.CreatedAt })
                    .SingleOrDefaultAsync();

                if (item == null) return Errors.SalesOrderItemNotFound;
                return item;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(int Id, UpdateSalesOrderItemParams Params)
        {
            try
            {
                SalesOrderItem? item = await _Context.SalesOrderItems.FindAsync(Id);
                if (item == null) return Errors.SalesOrderItemNotFound;
                item.Quantity = Params.Quantity;
                item.SellingPrice = Params.SellingPrice;
                item.Discount = Params.Discount;
                item.Total = Params.Total;
                _Context.SalesOrderItems.Update(item);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<SalesOrderItemDTO>>> GetBySalesOrderId(int SalesOrderId, int PageNumber, int PageSize)
        {
            try
            {
                IQueryable<SalesOrderItem> query = _Context.SalesOrderItems.AsNoTracking()
                    .Where(i => i.SalesOrderId == SalesOrderId && i.IsDeleted == false);
                int count = await query.CountAsync();

                List<SalesOrderItemDTO> items = await query
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .Select(i => new SalesOrderItemDTO() { Id = i.Id, SalesOrderId = i.SalesOrderId, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, SellingPrice = i.SellingPrice, Discount = i.Discount, Total = i.Total, CreatedAt = i.CreatedAt })
                    .ToListAsync();

                
                return new PagedResult<SalesOrderItemDTO>()
                {
                    Items = items,
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
    }
}
