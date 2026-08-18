using System.Data;
using ERP.Core.Entities;
using ERP.Core.EntityParams.salesOrderParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SalesOrderModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ERP.Infrastructure.Shared;

namespace ERP.Infrastructure.presistence.Repos
{
    public class SalesOrderRepo : ISalesOrderRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<SalesOrderRepo> _Logger;
        public SalesOrderRepo( AppDbContext context, ILogger<SalesOrderRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddSalesOrderParams Params)
        {
            try
            {
                SalesOrder order = new()
                {
                    CustomerId = Params.CustomerId,
                    Status = Params.Status,
                    Discount = Params.Discount,
                    Total = Params.Total,
                    CreatedAt = Params.CreatedAt
                };
                _Context.SalesOrders.Add(order);
                await _Context.SaveChangesAsync();
                return order.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Sales Order");
            }
        }

        public async Task<Result<bool>> UndoDelete(int Id,int WarehouseId)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                  if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }                  
                using (SqlCommand command = new SqlCommand("SP_UndoRemove", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@WarehouseId", WarehouseId);
                        command.Parameters.AddWithValue("@SalesOrderId", Id);

                        int affectedRows = await command.ExecuteNonQueryAsync();
                        if (affectedRows == -1)
                        {
                            return new Error("SaleOrderError", ErrorType.General, "Order Not Deleted Successfully!");
                        }
                        return true;
                    }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }
        public async Task<Result<bool>> Delete(int Id, string UserId,int WarehouseId)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }   
                using (SqlCommand command = new SqlCommand("SP_RemoveOrderId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SalesOrderId", Id);
                    command.Parameters.AddWithValue("@RemoveByUserId", UserId);
                    command.Parameters.AddWithValue("@WarehouseId", WarehouseId);

                    int affectedRows = await command.ExecuteNonQueryAsync();
                    if (affectedRows == -1)
                    {
                        return new Error("SaleOrderError", ErrorType.General, "Order Not Deleted Successfully!");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }

        public async Task<Result<SalesOrderDTO>> GetById(int Id)
        {
            try
            {
                SalesOrderDTO? order = await _Context.SalesOrders.AsNoTracking()
                    .Where(o => o.Id == Id && o.IsDeleted == false)
                    .Select(o => new SalesOrderDTO() { Id = o.Id, CustomerId = o.CustomerId, CustomerName = o.Customer != null ? o.Customer.FirstName + " " + o.Customer.LastName : null, Status = o.Status, PaymentStatus = o.PaymentStatus, Discount = o.Discount, Total = o.Total, CreatedAt = o.CreatedAt })
                    .SingleOrDefaultAsync();

                if (order == null) return Errors.SalesOrderNotFound;
                return order;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<SalesOrderDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<SalesOrder> query = _Context.SalesOrders.AsNoTracking()
                    .Where(o => o.IsDeleted == false && (Params.CustomerId == null || o.CustomerId == Params.CustomerId) && (Params.PaymentStatus == null || o.PaymentStatus == Params.PaymentStatus));

                int count = await query.CountAsync();

                List<SalesOrderDTO>? orders = await query
                    .OrderByDescending(o => o.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(o => new SalesOrderDTO() { Id = o.Id, CustomerId = o.CustomerId, CustomerName = o.Customer != null ? o.Customer.FirstName + " " + o.Customer.LastName : null, Status = o.Status, PaymentStatus = o.PaymentStatus, Discount = o.Discount, Total = o.Total, CreatedAt = o.CreatedAt })
                    .ToListAsync();

                return new PagedResult<SalesOrderDTO>()
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

        public async Task<Result<bool>> Update(int Id, UpdateSalesOrderParams Params)
        {
            try
            {
                SalesOrder? order = await _Context.SalesOrders.FindAsync(Id);
                if (order == null) return Errors.SalesOrderNotFound;
                order.Status = Params.Status;
                order.Discount = Params.Discount;
                order.Total = Params.Total;
                _Context.SalesOrders.Update(order);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
        public async Task<Result<int>> Sell(SellParams sellParams)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;
        
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                    using (SqlCommand command = new SqlCommand("SP_Sell", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValueOrNull("@CustomerId", sellParams.CustomerId);
                        command.Parameters.AddWithValue("@WarehouseId", sellParams.WarehouseId);
                        command.Parameters.AddWithValue("@Discount", sellParams.Discount);
                        command.Parameters.AddWithValue("@CreatedByUserId", sellParams.CreatedByUserId);
                        command.Parameters.AddWithValue("@PaymentStatus", sellParams.PaymentStatus);

                        DataTable ItemsDataTable = ConvertToDataTable(sellParams.Items);
                        SqlParameter tvpParam = command.Parameters.AddWithValue("@Items", ItemsDataTable);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "dbo.SalesItemsTable";

                        SqlParameter outputIdParam = new SqlParameter("@OrderId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        if (outputIdParam.Value == DBNull.Value)
                        {
                            return new Error("SaleOrderError", ErrorType.General, "Something Went Wrong!");
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

        
        private DataTable ConvertToDataTable(IEnumerable<Items> items)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("SellingPrice", typeof(decimal));
            table.Columns.Add("Discount", typeof(decimal));

            foreach (var item in items)
            {
                table.Rows.Add(item.ProductId, item.Quantity, item.SellingPrice, item.Discount);
            }
            return table;
        }

        public async Task<Result<bool>> CancelSalesOrder(int orderId, int warehouseId, string cancelledByUserId, CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync(cancellationToken);
                }

                using (SqlCommand command = new SqlCommand("SP_CancelSalesOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    command.Parameters.AddWithValue("@CancelledByUserId", cancelledByUserId);

                    int affected = await command.ExecuteNonQueryAsync(cancellationToken);
                    return affected != -1;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error in CancelSalesOrder: {ex}", ex);
                return new Error("InternalError", ErrorType.General, "Internal Error Happened during Cancel Sales Order");
            }
        }

        public async Task<Result<bool>> UpdateStatus(int orderId, int newStatus, CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync(cancellationToken);
                }

                using (SqlCommand command = new SqlCommand("SP_UpdateSalesOrderStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@NewStatus", newStatus);

                    int affected = await command.ExecuteNonQueryAsync(cancellationToken);
                    return affected != -1;
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error in UpdateStatus: {ex}", ex);
                return new Error("InternalError", ErrorType.General, "Internal Error Happened during Update Sales Order Status");
            }
        }
    }
}
