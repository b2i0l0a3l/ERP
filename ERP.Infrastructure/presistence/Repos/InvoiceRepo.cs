using System.Data;
using ERP.Core.Entities;
using ERP.Core.EntityParams.invoiceParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<InvoiceRepo> _Logger;
        public InvoiceRepo(AppDbContext context, ILogger<InvoiceRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddInvoiceParams Params)
        {
            try
            {
                Invoice invoice = new()
                {
                    InvoiceNumber = Params.InvoiceNumber,
                    Type = Params.Type,
                    Status = Params.Status,
                    CustomerId = Params.CustomerId,
                    SupplierId = Params.SupplierId,
                    IssueDate = Params.IssueDate,
                    DueDate = Params.DueDate,
                    SubTotal = Params.SubTotal,
                    TaxAmount = Params.TaxAmount,
                    DiscountAmount = Params.DiscountAmount,
                    TotalAmount = Params.TotalAmount,
                    Notes = Params.Notes,
                    CreatedByUserId = Params.CreatedByUserId
                };
                _Context.Invoices.Add(invoice);
                await _Context.SaveChangesAsync();
                return invoice.Id;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Invoice");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Invoice? invoice = await _Context.Invoices.FindAsync(Id);
                if (invoice == null) return Errors.InvoiceNotFound;
                invoice.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<InvoiceDTO>> GetById(int Id)
        {
            try
            {
                InvoiceDTO? invoice = await _Context.Invoices.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new InvoiceDTO()
                    {
                        Id = i.Id,
                        InvoiceNumber = i.InvoiceNumber,
                        Type = i.Type,
                        Status = i.Status,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer != null ? i.Customer.FirstName + " " + i.Customer.LastName : null,
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier != null ? i.Supplier.FullName : null,
                        IssueDate = i.IssueDate,
                        DueDate = i.DueDate,
                        SubTotal = i.SubTotal,
                        TaxAmount = i.TaxAmount,
                        DiscountAmount = i.DiscountAmount,
                        TotalAmount = i.TotalAmount,
                        Notes = i.Notes,
                        CreatedAt = i.CreatedAt
                    })
                    .SingleOrDefaultAsync();

                if (invoice == null) return Errors.InvoiceNotFound;
                return invoice;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<InvoiceDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Invoice> query = _Context.Invoices.AsNoTracking()
                    .Where(i => i.IsDeleted == false
                        && (Params.CustomerId == null || i.CustomerId == Params.CustomerId)
                        && (Params.SupplierId == null || i.SupplierId == Params.SupplierId)
                        && (Params.Status == null || i.Status == Params.Status)
                        && (Params.Type == null || i.Type == Params.Type));

                int count = await query.CountAsync();

                List<InvoiceDTO> invoices = await query
                    .OrderByDescending(i => i.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(i => new InvoiceDTO()
                    {
                        Id = i.Id,
                        InvoiceNumber = i.InvoiceNumber,
                        Type = i.Type,
                        Status = i.Status,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer != null ? i.Customer.FirstName + " " + i.Customer.LastName : null,
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier != null ? i.Supplier.FullName : null,
                        IssueDate = i.IssueDate,
                        DueDate = i.DueDate,
                        SubTotal = i.SubTotal,
                        TaxAmount = i.TaxAmount,
                        DiscountAmount = i.DiscountAmount,
                        TotalAmount = i.TotalAmount,
                        Notes = i.Notes,
                        CreatedAt = i.CreatedAt
                    })
                    .ToListAsync();

                return new PagedResult<InvoiceDTO>()
                {
                    Items = invoices,
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

        public async Task<Result<bool>> Update(int Id, UpdateInvoiceParams Params)
        {
            try
            {
                Invoice? invoice = await _Context.Invoices.FindAsync(Id);
                if (invoice == null) return Errors.InvoiceNotFound;
                invoice.Status = Params.Status;
                invoice.SubTotal = Params.SubTotal;
                invoice.TaxAmount = Params.TaxAmount;
                invoice.DiscountAmount = Params.DiscountAmount;
                invoice.TotalAmount = Params.TotalAmount;
                if (Params.Notes != null) invoice.Notes = Params.Notes;
                _Context.Invoices.Update(invoice);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<int>> CreateCompleteInvoice(CreateCompleteInvoiceParams Params)
        {
            try
            {
                var connection = _Context.Database.GetDbConnection() as SqlConnection;

                if (connection != null && connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
                using (SqlCommand command = new SqlCommand("SP_CreateCompleteInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@type", Params.Type );
                    command.Parameters.AddWithValue("@status", Params.Status);
                    command.Parameters.AddWithValue("@customerId", Params.CustomerId );
                    command.Parameters.AddWithValue("@CreatedByUserId", Params.CreatedByUserId );
                    command.Parameters.AddWithValue("@supplierId", Params.SupplierId );
                    command.Parameters.AddWithValue("@discountAmount", Params.DiscountAmount);
                    command.Parameters.AddWithValue("@notes", Params.Notes);
                    command.Parameters.AddWithValue("@OrderId", Params.OrderId );
                    command.Parameters.AddWithValue("@WarehouseId", Params.WarehouseId );

                    DataTable? ItemsDataTable = ConvertToDataTable(Params.Items);
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Items", ItemsDataTable );
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.InvoiceItems";

                    SqlParameter outputIdParam = new SqlParameter("@InvoiceId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    await command.ExecuteNonQueryAsync();
                    if (outputIdParam.Value == DBNull.Value)
                    {
                        return new Error("Invoice", ErrorType.General, "Something Went Wrong!");
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
        private DataTable? ConvertToDataTable(List<InvoiceItemRecord> records)
        {
            if (records.Count <= 0)
            {
                return null;
            }

            DataTable table = new DataTable();
            table.Columns.Add("productId", typeof(int));
            table.Columns.Add("description", typeof(string));
            table.Columns.Add("unitPrice", typeof(decimal));
            table.Columns.Add("taxRate", typeof(decimal));
            table.Columns.Add("quantity", typeof(string));

            foreach (var r in records)
            {
                table.Rows.Add(r.ProductId, r.Description, r.UnitePrice, r.TaxRate, r.Quantity);
            }
            return table;
        }
    }
}
