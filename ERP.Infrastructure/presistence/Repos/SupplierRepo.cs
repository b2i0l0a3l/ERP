using ERP.Core.Entities;
using ERP.Core.EntityParams.supplierParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.SupplierBalanceModels;
using ERP.Core.Models.SupplierModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<SupplierRepo> _Logger;
        public SupplierRepo(AppDbContext context, ILogger<SupplierRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddSupplierParams Params)
        {
            try
            {
                Supplier supplier = new()
                {
                    FirstName = Params.FirstName,
                    LastName = Params.LastName,
                    FullName = Params.FullName,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Suppliers.Add(supplier);
                await _Context.SaveChangesAsync();
                return supplier.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Supplier");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Supplier? supplier = await _Context.Suppliers.FindAsync(Id);
                if (supplier == null) return Errors.SupplierNotFound;
                supplier.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<SupplierDTO>> GetById(int Id)
        {
            try
            {
                SupplierDTO? supplier = await _Context.Suppliers.AsNoTracking()
                    .Where(s => s.Id == Id && s.IsDeleted == false)
                    .Select(s => new SupplierDTO() { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, FullName = s.FullName, CreatedAt = s.CreatedAt })
                    .SingleOrDefaultAsync();

                if (supplier == null) return Errors.SupplierNotFound;
                return supplier;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<SupplierDTO>> GetByName(string Name)
        {
            try
            {
                SupplierDTO? supplier = await _Context.Suppliers.AsNoTracking()
                    .Where(s => s.IsDeleted == false && (s.FullName.Contains(Name) || s.FirstName.Contains(Name) || s.LastName.Contains(Name)))
                    .Select(s => new SupplierDTO() { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, FullName = s.FullName, CreatedAt = s.CreatedAt })
                    .FirstOrDefaultAsync();

                if (supplier == null) return Errors.SupplierNotFound;
                return supplier;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
        public async Task<Result<SupplierBalanceDTO>> GetSupplierBalance(int SupplierId)
        {
            try
            {
                bool exists = await _Context.Suppliers.AnyAsync(s => s.Id == SupplierId && s.IsDeleted == false);
                if (!exists) return Errors.SupplierNotFound;

                decimal totalPurchases = await _Context.PurchaseOrders
                    .Where(o => o.SupplierId == SupplierId && o.IsDeleted == false)
                    .SumAsync(o => o.Total);

                IQueryable<int> supplierOrderIds = _Context.PurchaseOrders
                    .Where(o => o.SupplierId == SupplierId && o.IsDeleted == false)
                    .Select(o => o.Id);

                decimal totalPaid = await _Context.Payments
                    .Where(p => p.IsDeleted == false && p.PurchaseOrderId != null && supplierOrderIds.Contains(p.PurchaseOrderId.Value))
                    .SumAsync(p => p.Amount);

                return new SupplierBalanceDTO
                {
                    SupplierId = SupplierId,
                    TotalPurchases = totalPurchases,
                    TotalPaid = totalPaid,
                    Balance = totalPurchases - totalPaid
                };
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<SupplierDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Supplier> query = _Context.Suppliers.AsNoTracking()
                    .Where(s => s.IsDeleted == false && (Params.Name == null || s.FullName.ToLower().Contains(Params.Name.ToLower()) || s.FirstName.ToLower().Contains(Params.Name.ToLower()) || s.LastName.ToLower().Contains(Params.Name.ToLower())));

                int count = await query.CountAsync();

                List<SupplierDTO>? suppliers = await query
                    .OrderByDescending(s => s.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(s => new SupplierDTO() { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, FullName = s.FullName, CreatedAt = s.CreatedAt })
                    .ToListAsync();

                return new PagedResult<SupplierDTO>()
                {
                    Items = suppliers,
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

        public async Task<Result<bool>> Update(int Id, UpdateSupplierParams Params)
        {
            try
            {
                Supplier? supplier = await _Context.Suppliers.FindAsync(Id);
                if (supplier == null) return Errors.SupplierNotFound;
                supplier.FirstName = Params.FirstName;
                supplier.LastName = Params.LastName;
                supplier.FullName = Params.FullName;
                _Context.Suppliers.Update(supplier);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
