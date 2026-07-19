using ERP.Core.Interfaces;
using ERP.Infrastructure.presistence;
using ERP.Infrastructure.presistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure.Shared
{
    public static  class InfrastructurServiceRegistration
    {
        public static void AddInfrastructurServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MyConn");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection String not found");
            } 
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IBrandRepo, BrandRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ICustomerAddressRepo, CustomerAddressRepo>();
            services.AddScoped<ICustomerPhoneNumberRepo, CustomerPhoneNumberRepo>();
            services.AddScoped<IInventoryRepo, InventoryRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IProductImageRepo, ProductImageRepo>();
            services.AddScoped<IPurchaseOrderRepo, PurchaseOrderRepo>();
            services.AddScoped<IPurchaseOrderItemRepo, PurchaseOrderItemRepo>();
            services.AddScoped<ISalesOrderRepo, SalesOrderRepo>();
            services.AddScoped<ISalesOrderItemRepo, SalesOrderItemRepo>();
            services.AddScoped<ISettingRepo, SettingRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IWarehouseRepo, WarehouseRepo>();
        }
    }
}