using System.Data;
using ERP.Core.Entities;
using ERP.Core.EntityParams.paymentParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.PaymentModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly AppDbContext _Context;
        private readonly IConfiguration _Config;

        private readonly ILogger<PaymentRepo> _Logger;
        public PaymentRepo(IConfiguration config, AppDbContext context, ILogger<PaymentRepo> logger)
        {
            _Context = context;
            _Logger = logger;
            _Config = config;
        }

        public async Task<Result<int>> Pay(PayParmas PayParams)
        {
             try
            {
               var connection = _Context.Database.GetDbConnection() as SqlConnection;
        
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                    using (SqlCommand command = new SqlCommand("SP_Pay", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Amount", PayParams.Amount);
                        command.Parameters.AddWithValue("@Notes",  PayParams.Notes );
                        command.Parameters.AddWithValue("@SaleOrderId", PayParams.SaleOrderId );
                        command.Parameters.AddWithValue("@PaymentMethod", PayParams.PaymentMethod);
                        command.Parameters.AddWithValue("@PurchaseOrderId", PayParams.PurchaseOrderId );
                        command.Parameters.AddWithValue("@ReferenceNumber", PayParams.ReferenceNumber );
                        command.Parameters.AddWithValue("@CreatedByUserId", PayParams.CreatedByUserId);


                        SqlParameter outputIdParam = new SqlParameter("@PayId", SqlDbType.Int)
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

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Payment? payment = await _Context.Payments.FindAsync(Id);
                if (payment == null) return Errors.PaymentNotFound;
                payment.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PaymentDTO>> GetById(int Id)
        {
            try
            {
                PaymentDTO? payment = await _Context.Payments.AsNoTracking()
                    .Where(p => p.Id == Id && p.IsDeleted == false)
                    .Select(p => new PaymentDTO() { Id = p.Id, SaleOrderId = p.SaleOrderId, PurchaseOrderId = p.PurchaseOrderId, Amount = p.Amount, Notes = p.Notes, ReferenceNumber = p.ReferenceNumber, PaymentMethod = p.PaymentMethod, CreatedAt = p.CreatedAt })
                    .SingleOrDefaultAsync();

                if (payment == null) return Errors.PaymentNotFound;
                return payment;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<PaymentDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Payment> query = _Context.Payments.AsNoTracking()
                    .Where(p => p.IsDeleted == false && (Params.SaleOrderId == null || p.SaleOrderId == Params.SaleOrderId) && (Params.PurchaseOrderId == null || p.PurchaseOrderId == Params.PurchaseOrderId));

                int count = await query.CountAsync();

                List<PaymentDTO>? payments = await query
                    .OrderByDescending(p => p.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(p => new PaymentDTO() { Id = p.Id, SaleOrderId = p.SaleOrderId, PurchaseOrderId = p.PurchaseOrderId, Amount = p.Amount, Notes = p.Notes, ReferenceNumber = p.ReferenceNumber, PaymentMethod = p.PaymentMethod, CreatedAt = p.CreatedAt })
                    .ToListAsync();

                return new PagedResult<PaymentDTO>()
                {
                    Items = payments,
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
    }
}
