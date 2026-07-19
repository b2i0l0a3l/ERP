using ERP.Core.Entities;
using ERP.Core.EntityParams.customerPhoneNumberParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.CustomerPhoneNumberModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class CustomerPhoneNumberRepo : ICustomerPhoneNumberRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<CustomerPhoneNumberRepo> _Logger;
        public CustomerPhoneNumberRepo(AppDbContext context, ILogger<CustomerPhoneNumberRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

        public async Task<Result<int>> Add(AddCustomerPhoneNumberParams Params)
        {
            try
            {
                CustomerPhoneNumber phone = new()
                {
                    CustomerId = Params.CustomerId,
                    PhoneNumber = Params.PhoneNumber,
                    CreatedAt = Params.CreatedAt
                };
                _Context.CustomerPhoneNumbers.Add(phone);
                await _Context.SaveChangesAsync();
                return phone.Id;
            }
            catch
            {
                return new Error("UnexpectedError", ErrorType.General, "Error Happend While Adding Customer Phone Number");
            }
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                CustomerPhoneNumber? phone = await _Context.CustomerPhoneNumbers.FindAsync(Id);
                if (phone == null) return Errors.CustomerPhoneNumberNotFound;
                phone.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<CustomerPhoneNumberDTO>> GetById(int Id)
        {
            try
            {
                CustomerPhoneNumberDTO? phone = await _Context.CustomerPhoneNumbers.AsNoTracking()
                    .Where(p => p.Id == Id && p.IsDeleted == false)
                    .Select(p => new CustomerPhoneNumberDTO() { Id = p.Id, CustomerId = p.CustomerId, PhoneNumber = p.PhoneNumber, CreatedAt = p.CreatedAt })
                    .SingleOrDefaultAsync();

                if (phone == null) return Errors.CustomerPhoneNumberNotFound;
                return phone;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<bool>> Update(int Id, UpdateCustomerPhoneNumberParams Params)
        {
            try
            {
                CustomerPhoneNumber? phone = await _Context.CustomerPhoneNumbers.FindAsync(Id);
                if (phone == null) return Errors.CustomerPhoneNumberNotFound;
                phone.PhoneNumber = Params.PhoneNumber;
                _Context.CustomerPhoneNumbers.Update(phone);
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
