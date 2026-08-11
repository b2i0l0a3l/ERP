using ERP.Application.services;
using ERP.Application.Shared;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Shared;
using ERP.Api.BackgroundServices;
using ERP.Infrastructure.Extensions;
using ERP.Api.Services;
using Microsoft.OpenApi.Models;


namespace ERP.Api.shared
{
    public static class ErpApiRegistiration
    {
        public static void AddApiServiceRegistration(this IServiceCollection Services, IConfiguration configuration, IWebHostEnvironment environment)
        {

            string wwwrootPath = environment.WebRootPath ?? Path.Combine(environment.ContentRootPath, "wwwroot");

            Services.AddInfrastructurServiceRegistration(configuration,environment);
            Services.AddApplicationServiceRegistration();
            Services.AddOutputCache(options =>
            {
                options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(10);
                options.SizeLimit = 100 * 1024 * 1024;
            });

            Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ERP API",
        Version = "v1",
        Description = "ERP System API with JWT Authentication"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please Enter Your Token Here  : Bearer {your_token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


            Services.AddScoped<IFileStorageService>(sp =>
                new LocalFileStorageService(wwwrootPath));

            Services.AddScoped<IRemoveFile>(sp =>
                new RemoveFile(wwwrootPath));

            Services.AddSignalR();
            Services.AddHostedService<ERPBackgroundService>();
            Services.AddScoped<IPeriodicCheck, ERP.Api.Services.OverduePaymentsPeriodicCheck>();
            Services.AddScoped<IPeriodicCheck, ERP.Api.Services.LowStockPeriodicCheck>();

            Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(origin => true)
                          .AllowCredentials();
                });
            });


            Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            FontRegistrationExtensions.RegisterPdfFonts();
            Services.AddScoped<INotificationSender, SignalRNotificationSender>();
        }
    }
}