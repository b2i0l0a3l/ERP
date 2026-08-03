using ERP.Core.Entities;
using ERP.Core.EntityParams.invoiceItemParams;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.presistence.Repos
{
    public class InvoiceItemRepo : IInvoiceItemRepo
    {
        private readonly AppDbContext _Context;
        private readonly ILogger<InvoiceItemRepo> _Logger;
        public InvoiceItemRepo(AppDbContext context, ILogger<InvoiceItemRepo> logger)
        {
            _Context = context;
            _Logger = logger;
        }

       

        public async Task<Result<bool>> Delete(int Id)
        {
            try
            {
                InvoiceItem? item = await _Context.InvoiceItems.FindAsync(Id);
                if (item == null) return Errors.InvoiceItemNotFound;
                item.IsDeleted = true;
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<InvoiceItemDTO>> GetById(int Id)
        {
            try
            {
                InvoiceItemDTO? item = await _Context.InvoiceItems.AsNoTracking()
                    .Where(i => i.Id == Id && i.IsDeleted == false)
                    .Select(i => new InvoiceItemDTO()
                    {
                        Id = i.Id,
                        InvoiceId = i.InvoiceId,
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name , 
                        Description = i.Description,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        TaxRate = i.TaxRate,
                        LineTotal = i.LineTotal,
                        CreatedAt = i.CreatedAt
                    })
                    .SingleOrDefaultAsync();

                if (item == null) return Errors.InvoiceItemNotFound;
                return item;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Error : {ex}", ex);
                return new Error("InternelError", ErrorType.General, "Internel Error Happend");
            }
        }

        public async Task<Result<PagedResult<InvoiceItemDTO>>> GetPaged(GetPagedAsyncParams Params)
        {
            try
            {
                IQueryable<InvoiceItem> query = _Context.InvoiceItems.AsNoTracking()
                    .Where(i => i.IsDeleted == false && (Params.InvoiceId == null || i.InvoiceId == Params.InvoiceId));

                int count = await query.CountAsync();

                List<InvoiceItemDTO> items = await query
                    .OrderByDescending(i => i.CreatedAt)
                    .Skip((Params.PageNumber - 1) * Params.PageSize)
                    .Take(Params.PageSize)
                    .Select(i => new InvoiceItemDTO()
                    {
                        Id = i.Id,
                        InvoiceId = i.InvoiceId,
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Description = i.Description,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        TaxRate = i.TaxRate,
                        LineTotal = i.LineTotal,
                        CreatedAt = i.CreatedAt
                    })
                    .ToListAsync();

                return new PagedResult<InvoiceItemDTO>()
                {
                    Items = items,
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



        public async Task<Result<List<InvoiceItemDTO>>> GetByInvoiceId(int InvoiceId)
        {
            try
            {
                List<InvoiceItemDTO> items = await _Context.InvoiceItems.AsNoTracking()
                    .Where(i => i.InvoiceId == InvoiceId && i.IsDeleted == false)
                    .Select(i => new InvoiceItemDTO()
                    {
                        Id = i.Id,
                        InvoiceId = i.InvoiceId,
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Description = i.Description,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        TaxRate = i.TaxRate,
                        LineTotal = i.LineTotal,
                        CreatedAt = i.CreatedAt
                    })
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
