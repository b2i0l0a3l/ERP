using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Interfaces;
using ERP.Core.Models.DashboardModels;
using ERP.Core.Models.InventoryModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<DashboardRepo> _Logger;
        public DashboardRepo(AppDbContext context,ILogger<DashboardRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }
        public async Task<Result<SummaryModel>> Summary()
        {
            SummaryModel? result = null;
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_GetDashboardSummary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = new SummaryModel()
                            {
                                FullyPaidOrders = reader.GetInt32(reader.GetOrdinal("FullyPaidOrders")),
                                NotPaidOrders = reader.GetInt32(reader.GetOrdinal("NotPaidOrders")),
                                PartialPaidOrders = reader.GetInt32(reader.GetOrdinal("PartialPaidOrders")),
                                TotalCustomers = reader.GetInt32(reader.GetOrdinal("TotalCustomers")),
                                TotalProducts = reader.GetInt32(reader.GetOrdinal("TotalProducts")),
                                TotalPurchase = reader.GetInt32(reader.GetOrdinal("TotalPurchase")),
                                FullyPaidPurchase = reader.GetInt32(reader.GetOrdinal("FullyPaidPurchase")),
                                NotPaidPurchase = reader.GetInt32(reader.GetOrdinal("NotPaidPurchase")),
                                PartialPaidPurchase = reader.GetInt32(reader.GetOrdinal("PartialPaidPurchase")),
                                TotalPurchaseItems = reader.GetInt32(reader.GetOrdinal("TotalPurchaseItems")),
                                TotalSales = reader.GetInt32(reader.GetOrdinal("TotalSales"))
                            };
                        }
                    }
                    if (result == null)
                    {
                        return new Error("SummaryNotFound", ErrorType.General, "Summary is Empty");
                    }
                    return result;
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }
        public async Task<Result<List<SaleRaport>>> SaleRaport(DateOnly From, DateOnly To)
        {
            List<SaleRaport>? result = new();
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_GetSalesReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@From", From);
                    command.Parameters.AddWithValue("@To", To);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new SaleRaport()
                            {
                                DateValue = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateValue"))),
                                Profit = reader.GetDecimal(reader.GetOrdinal("Profit")),
                                TotalDiscounts = reader.GetDecimal(reader.GetOrdinal("TotalDiscounts")),
                                TotalOrders = reader.GetInt32(reader.GetOrdinal("TotalOrders")),
                                TotalRevenue = reader.GetDecimal(reader.GetOrdinal("TotalRevenue")),
                                TotalUnitsSold = reader.GetInt32(reader.GetOrdinal("TotalUnitsSold")),
                            });
                        }
                    }
                    if (result == null)
                    {
                        return new Error("SaleRaportFound", ErrorType.General, "Sale raport Not found");
                    }
                    return result;
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }

        public async Task<Result<List<PurchaseRaport>>> PurchaseRaport(DateOnly From, DateOnly To)
        {
            List<PurchaseRaport>? result = new();
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_PurchaseReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@From", From);
                    command.Parameters.AddWithValue("@To", To);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new PurchaseRaport()
                            {
                                DateValue = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateValue"))),
                                TotalItemLines = reader.GetInt32(reader.GetOrdinal("TotalItemLines")),
                                TotalOrdersCount = reader.GetInt32(reader.GetOrdinal("TotalOrdersCount")),
                                TotalPurchaseAmount = reader.GetDecimal(reader.GetOrdinal("TotalPurchaseAmount")),
                                TotalQuantityPurchased = reader.GetInt32(reader.GetOrdinal("TotalQuantityPurchased")),
                            });
                        }
                    }
                    if (result == null)
                    {
                        return new Error("PurchaseRaportFound", ErrorType.General, "Purchase raport Not found");
                    }
                    return result;
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }
        public async Task<Result<List<InventoryDTO>>> GetLowStock()
        {
            try
            {
                List<InventoryDTO> items = await _Context.Inventories.AsNoTracking()
                .Where(i => i.IsDeleted == false && i.Quantity <= i.MinThreshold)
                .Select(i => new InventoryDTO() { Id = i.Id, WarehouseId = i.WarehouseId, WarehouseName = i.Warehouse.Name, ProductId = i.ProductId, ProductName = i.Product.Name, Quantity = i.Quantity, MinThreshold = i.MinThreshold, CreatedAt = i.CreatedAt })
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