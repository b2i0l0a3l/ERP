using ERP.Core.Entities;
using ERP.Core.EntityParams.customerParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<CustomerRepo> _Logger;
        public CustomerRepo(AppDbContext context, ILogger<CustomerRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddCustomerParams Params)
        {
            try
            {
                Customer customer = new()
                {
                    FristName = Params.FristName,
                    LastName = Params.LastName,
                    Info = Params.Info,
                    CreatedAt = Params.CreatedAt
                };
                _Context.Customers.Add(customer);
                await _Context.SaveChangesAsync();
                return customer.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Customer");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                Customer? customer = await _Context.Customers.FindAsync(Id);
                if (customer == null) return Errors.CustomerNotFound;
                customer.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<CustomerDTO>> GetById(int Id)
        {
            try
            {
                CustomerDTO? customer = await _Context.Customers.AsNoTracking()
                    .Where(c => c.Id == Id && c.IsDeleted == false)
                    .Select(c => new CustomerDTO() { Id = c.Id, FristName = c.FristName, LastName = c.LastName, Info = c.Info, CreatedAt = c.CreatedAt })
                    .SingleOrDefaultAsync();

                if (customer == null) return Errors.CustomerNotFound;
                return customer;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<CustomerDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<Customer> query = _Context.Customers.AsNoTracking()
                    .Where(c => c.IsDeleted == false && (Params.Name == null || c.FristName.ToLower().Contains(Params.Name.ToLower()) || c.LastName.ToLower().Contains(Params.Name.ToLower())));

                int count = await query.CountAsync();

                List<CustomerDTO>? customers = await query
                    .OrderByDescending(c => c.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(c => new CustomerDTO() { Id = c.Id, FristName = c.FristName, LastName = c.LastName, Info = c.Info, CreatedAt = c.CreatedAt })
                    .ToListAsync();

                return new PagedResult<CustomerDTO>()
                {
                    Items = customers,
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

        public async Task<Result<bool>> Update(int Id, UpdateCustomerParams Params)
        {
            try
            {
                Customer? customer = await _Context.Customers.FindAsync(Id);
                if (customer == null) return Errors.CustomerNotFound;
                customer.FristName = Params.FristName;
                customer.LastName = Params.LastName;
                customer.Info = Params.Info;
                _Context.Customers.Update(customer);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<decimal>> GetCustomerBalance(int CustomerId)
        {
            try
            {
                Customer? customer = await _Context.Customers.FindAsync(CustomerId);
                if (customer == null) return Errors.CustomerNotFound;

                decimal balance = await _Context.SalesOrders
                    .Where(o => o.CustomerId == CustomerId && o.IsDeleted == false)
                    .SumAsync(o => o.Total - o.PaidAmount);

                return balance;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }
    }
}
