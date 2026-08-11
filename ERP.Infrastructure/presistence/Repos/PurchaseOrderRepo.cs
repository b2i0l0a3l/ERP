using ERP.Core.Entities;
using ERP.Core.EntityParams.purchaseOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PurchaseOrderModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace ERP.Infrastructure.presistence.Repos
{
    public class PurchaseOrderRepo : IPurchaseOrderRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<PurchaseOrderRepo> _Logger;
        private readonly IConfiguration _Config;
        public PurchaseOrderRepo(IConfiguration config, AppDbContext context, ILogger<PurchaseOrderRepo> logger)
        {
            _Context = context;
            _Logger = logger;
            _Config = config;
        }

        public async Task<Result<int>> Add(AddPurchaseOrderParams Params)
        {
            try
            {
                PurchaseOrder order = new()
                {
                    SupplierId = Params.SupplierId,
                    OrderStatus = Params.OrderStatus,
                    Total = Params.Total,
                    CreatedAt = Params.CreatedAt
                };
                _Context.PurchaseOrders.Add(order);
                await _Context.SaveChangesAsync();
                return order.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Purchase Order");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                PurchaseOrder? order = await _Context.PurchaseOrders.FindAsync(Id);
                if (order == null) return Errors.PurchaseOrderNotFound;
                order.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PurchaseOrderDTO>> GetById(int Id)
        {
            try
            {
                PurchaseOrderDTO? order = await _Context.PurchaseOrders.AsNoTracking()
                    .Where(o => o.Id == Id && o.IsDeleted == false)
                    .Select(o => new PurchaseOrderDTO() { Id = o.Id, SupplierId = o.SupplierId, SupplierName = o.Supplier.FullName, OrderStatus = o.OrderStatus, PaymentStatus = o.PaymentStatus, Total = o.Total, CreatedAt = o.CreatedAt })
                    .SingleOrDefaultAsync();

                if (order == null) return Errors.PurchaseOrderNotFound;
                return order;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<PurchaseOrderDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<PurchaseOrder> query = _Context.PurchaseOrders.AsNoTracking()
                    .Where(o => o.IsDeleted == false && (Params.SupplierId == null || o.SupplierId == Params.SupplierId) && (Params.PaymentStatus == null || o.PaymentStatus == Params.PaymentStatus));

                int count = await query.CountAsync();

                List<PurchaseOrderDTO>? orders = await query
                    .OrderByDescending(o => o.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(o => new PurchaseOrderDTO() { Id = o.Id, SupplierId = o.SupplierId, SupplierName = o.Supplier.FullName, OrderStatus = o.OrderStatus, PaymentStatus = o.PaymentStatus, Total = o.Total, CreatedAt = o.CreatedAt })
                    .ToListAsync();

                return new PagedResult<PurchaseOrderDTO>()
                {
                    Items = orders,
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

        public async Task<Result<bool>> Update(int Id, UpdatePurchaseOrderParams Params)
        {
            try
            {
                PurchaseOrder? order = await _Context.PurchaseOrders.FindAsync(Id);
                if (order == null) return Errors.PurchaseOrderNotFound;
                order.OrderStatus = Params.OrderStatus;
                order.Total = Params.Total;
                _Context.PurchaseOrders.Update(order);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<int>> Buy(BuyParams BuyParams)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_Buy", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierId", BuyParams.SupplierId);
                    command.Parameters.AddWithValue("@WarehouseId", BuyParams.WarehouseId);
                    command.Parameters.AddWithValue("@CreatedByUserId", BuyParams.CreatedByUserId);

                    DataTable ItemsDataTable = ConvertToDataTable(BuyParams.Items);
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Items", ItemsDataTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.BuyItems";

                    SqlParameter outputIdParam = new SqlParameter("@BuyId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    await command.ExecuteNonQueryAsync();
                    if (outputIdParam.Value == DBNull.Value)
                    {
                        return new Error("PurchaseOrderError", ErrorType.General, "Something Went Wrong!");
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
        private DataTable ConvertToDataTable(IEnumerable<BuyItems> items)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("SellingPrice", typeof(decimal));

            foreach (var item in items)
            {
                table.Rows.Add(item.ProductId, item.Quantity, item.SellingPrice);
            }
            return table;
        }
    }
}
