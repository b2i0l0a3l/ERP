using System.Data;
using Microsoft.Data.SqlClient;
using ERP.Core.Entities;
using ERP.Core.EntityParams.inventoryParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.Infrastructure.Shared;

namespace ERP.Infrastructure.presistence.Repos
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<InventoryRepo> _Logger;
        public InventoryRepo(AppDbContext context, ILogger<InventoryRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddInventoryParams Params)
        {
            try
            {
                Inventory inventory = new()
                {
                    WarehouseId = Params.WarehouseId,
                    ProductId = Params.ProductId,
                    Quantity = Params.Quantity,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Inventories.Add(inventory);
                await _Context.SaveChangesAsync();
                return inventory.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Inventory");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Inventory? inventory = await _Context.Inventories.FindAsync(Id);
                if (inventory == null) return Errors.InventoryNotFound;
                inventory.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<InventoryDTO>> GetById(int Id)
        {
            try
            {
                InventoryDTO? inventory = await _Context.Inventories.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new InventoryDTO() { Id = i.Id, WarehouseId = i.WarehouseId, WarehouseName = i.Warehouse.Name, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, MinThreshold = i.MinThreshold, CreatedAt = i.CreatedAt })
                    .SingleOrDefaultAsync();

                if (inventory == null) return Errors.InventoryNotFound;
                return inventory;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<InventoryDTO>> GetByProductId(int ProductId)
        {
            try
            {
                InventoryDTO? inventory = await _Context.Inventories.AsNoTracking()
                    .Where(i => i.ProductId == ProductId && i.IsDeleted == false)
                    .Select(i => new InventoryDTO() { Id = i.Id, WarehouseId = i.WarehouseId, WarehouseName = i.Warehouse.Name, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, MinThreshold = i.MinThreshold, CreatedAt = i.CreatedAt })
                    .FirstOrDefaultAsync();

                if (inventory == null) return Errors.InventoryNotFound;
                return inventory;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<InventoryDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Inventory> query = _Context.Inventories.AsNoTracking()
                    .Where(i => i.IsDeleted == false && (Params.WarehouseId == null || i.WarehouseId == Params.WarehouseId) && (Params.ProductId == null || i.ProductId == Params.ProductId) && (Params.ProductName == null || i.Product.Name.Contains(Params.ProductName)));

                int count = await query.CountAsync();

                List<InventoryDTO>? items = await query
                    .OrderByDescending(i => i.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(i => new InventoryDTO() { Id = i.Id, WarehouseId = i.WarehouseId, WarehouseName = i.Warehouse.Name, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, MinThreshold = i.MinThreshold, CreatedAt = i.CreatedAt })
                    .ToListAsync();

                return new PagedResult<InventoryDTO>()
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

        public async Task<Result<bool>> Update(int Id, UpdateInventoryParams Params)
        {
            try
            {
                Inventory? inventory = await _Context.Inventories.FindAsync(Id);
                if (inventory == null) return Errors.InventoryNotFound;
                inventory.Quantity = Params.Quantity;
                _Context.Inventories.Update(inventory);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> TransferStock(int fromWarehouseId, int toWarehouseId, int productId, int quantity, string adjustedByUserId, string? reason = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync(cancellationToken);
                }

                using (SqlCommand command = new SqlCommand("SP_TransferStock", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromWarehouseId", fromWarehouseId);
                    command.Parameters.AddWithValue("@ToWarehouseId", toWarehouseId);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@AdjustedByUserId", adjustedByUserId);
                    command.Parameters.AddWithValueOrNull("@Reason", reason);

                    int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken);
                    return affectedRows != -1;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error: {ex}", ex);
                return new Error("InternalError", ErrorType.General, "Internal Error Happened during Stock Transfer");
            }
        }

        public async Task<Result<bool>> AdjustInventory(int warehouseId, int productId, int newQuantity, string adjustedByUserId, string reason, CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync(cancellationToken);
                }

                using (SqlCommand command = new SqlCommand("SP_AdjustInventory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    command.Parameters.AddWithValue("@AdjustedByUserId", adjustedByUserId);
                    command.Parameters.AddWithValue("@Reason", reason);

                    int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken);
                    return affectedRows != -1;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error: {ex}", ex);
                return new Error("InternalError", ErrorType.General, "Internal Error Happened during Inventory Adjustment");
            }
        }
    }
}
