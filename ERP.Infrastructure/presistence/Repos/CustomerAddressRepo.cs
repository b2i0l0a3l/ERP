using ERP.Core.Entities;
using ERP.Core.EntityParams.customerAddressParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerAddressModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class CustomerAddressRepo : ICustomerAddressRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<CustomerAddressRepo> _Logger;
        public CustomerAddressRepo(AppDbContext context, ILogger<CustomerAddressRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddCustomerAddressParams Params)
        {
            try
            {
                CustomerAddress address = new()
                {
                    CustomerId = Params.CustomerId,
                    Name = Params.Name,
                    Description = Params.Description,
                    CreatedAt = Params.CreatedAt
                };
                _Context.CustomerAddresses.Add(address);
                await _Context.SaveChangesAsync();
                return address.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Customer Address");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                CustomerAddress? address = await _Context.CustomerAddresses.FindAsync(Id);
                if (address == null) return Errors.CustomerAddressNotFound;
                address.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<CustomerAddressDTO>> GetById(int Id)
        {
            try
            {
                CustomerAddressDTO? address = await _Context.CustomerAddresses.AsNoTracking()
                    .Where(a => a.Id == Id && a.IsDeleted == false)
                    .Select(a => new CustomerAddressDTO() { Id = a.Id, CustomerId = a.CustomerId, Name = a.Name, Description = a.Description, CreatedAt = a.CreatedAt })
                    .SingleOrDefaultAsync();

                if (address == null) return Errors.CustomerAddressNotFound;
                return address;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<CustomerAddressDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<CustomerAddress> query = _Context.CustomerAddresses.AsNoTracking()
                    .Where(a => a.IsDeleted == false && (Params.CustomerId == null || a.CustomerId == Params.CustomerId));

                int count = await query.CountAsync();

                List<CustomerAddressDTO>? addresses = await query
                    .OrderByDescending(a => a.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(a => new CustomerAddressDTO() { Id = a.Id, CustomerId = a.CustomerId, Name = a.Name, Description = a.Description, CreatedAt = a.CreatedAt })
                    .ToListAsync();

                return new PagedResult<CustomerAddressDTO>()
                {
                    Items = addresses,
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

        public async Task<Result<bool>> Update(int Id, UpdateCustomerAddressParams Params)
        {
            try
            {
                CustomerAddress? address = await _Context.CustomerAddresses.FindAsync(Id);
                if (address == null) return Errors.CustomerAddressNotFound;
                address.Name = Params.Name;
                address.Description = Params.Description;
                _Context.CustomerAddresses.Update(address);
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
