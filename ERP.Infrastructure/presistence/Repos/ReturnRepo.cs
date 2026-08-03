using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.EntityParams.returnParams;
using ERP.Core.Interfaces;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class ReturnRepo : IReturnRepo
    {
        private readonly ILogger<ReturnRepo> _Logger;
        private readonly AppDbContext _Context;
        public ReturnRepo(AppDbContext context, ILogger<ReturnRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result> Delete(int ReturnId, string UserId)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_DeleteReturnRecord", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReturnId", ReturnId);
                    command.Parameters.AddWithValue("@CreatedByUserId", UserId);

                    int affectedRows = await command.ExecuteNonQueryAsync();

                    return affectedRows != -1 ? Result.Success() : Errors.ReturnNotFound;

                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }
        public async Task<Result> UndoReturn(int ReturnId)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_UndoReturn", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReturnId", ReturnId);

                    int affectedRows = await command.ExecuteNonQueryAsync();

                    return affectedRows != -1 ? Result.Success() : Errors.ReturnNotFound;

                }

            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");

            }
        }

        public async Task<Result<int>> Return(ReturnParam returnParam)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_Return", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SaleOrderId" , returnParam.SaleOrderId);
                    command.Parameters.AddWithValue("@WarehouseId", returnParam.WarehouseId);
                    command.Parameters.AddWithValue("@Reason", returnParam.Reason);
                    command.Parameters.AddWithValue("@CreatedByUserId", returnParam.CreatedByUserId);
                    command.Parameters.AddWithValue("@Status", returnParam.Status);

                    DataTable ItemsDataTable = ConvertToDataTable(returnParam.Items);
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Items", ItemsDataTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.ReturnItems";

                    SqlParameter outputIdParam = new SqlParameter("@ReturnId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    await command.ExecuteNonQueryAsync();
                    if (outputIdParam.Value == DBNull.Value)
                    {
                        return new Error("ReturnError", ErrorType.General, "Something Went Wrong!");
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
        private DataTable ConvertToDataTable(IEnumerable<ReturnItemParam> items)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("RefundAmount", typeof(decimal));
            table.Columns.Add("Condition", typeof(int));

            foreach (var item in items)
            {
                table.Rows.Add(item.ProductId, item.Quantity, item.RefundAmount, item.Condition);
            }
            return table;
        }
    }
}