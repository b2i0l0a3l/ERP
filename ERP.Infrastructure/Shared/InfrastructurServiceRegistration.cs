using System.Text;
using ERP.Core.Entities;
using ERP.Core.Interfaces;
using ERP.Core.Models.AuthModels;
using ERP.Infrastructure.presistence;
using ERP.Infrastructure.presistence.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mediator;
using FluentValidation;

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

            // ─── ASP.NET Identity ───────────────────────────────────────
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // ─── JWT Configuration ──────────────────────────────────────
       
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:ISSUER"],
                    ValidAudience = configuration["JWT:AUDIENCE"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:KEY"] ?? "defaultt0s3c2hlla1anndbi1lad1eut_SecureSuperSecretKey256Bits")),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();

            // ─── Mediator ───────────────────────────────────────────────
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
            // ─── Services ───────────────────────────────────────────────
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBuildPdf, BuildPDF>();
            services.AddScoped<IDashboardRepo, DashboardRepo>();
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
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped<IInvoiceItemRepo, InvoiceItemRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<IReturnRepo, ReturnRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRefreshTokenRepo, RefreshTokenRepo>();
        }
    }
}