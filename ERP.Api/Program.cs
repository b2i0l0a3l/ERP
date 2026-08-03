using ERP.Application.services;
using ERP.Application.Shared;
using ERP.Core.Interfaces;
using ERP.Infrastructure.Shared;
using ERP.Api.Middlewares;
using QuestPDF;
using QuestPDF.Infrastructure;
using Serilog;
using Serilog.Events;
using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentUserName()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var environment = builder.Environment;
string wwwrootPath = environment.WebRootPath ?? Path.Combine(environment.ContentRootPath, "wwwroot");

Settings.License = LicenseType.Community;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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

builder.Services.AddControllers();

IConfiguration configuration = builder.Configuration; 
builder.Services.AddInfrastructurServiceRegistration(configuration);
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(2);
    options.SizeLimit = 100 * 1024 * 1024;
});
builder.Services.AddScoped<IFileStorageService>(sp =>
    new LocalFileStorageService(wwwrootPath));
    
builder.Services.AddScoped<IRemoveFile>(sp =>
    new RemoveFile(wwwrootPath));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "Handled {RequestPath}";
    options.GetLevel = (httpContext, elapsed, ex) =>
    {
        var path = httpContext.Request.Path.Value?.ToLower();

        if (path != null && (
            path.StartsWith("/scalar") ||
            path.StartsWith("/swagger") ||
            path.StartsWith("/openapi") ||
            path.EndsWith(".js") ||
            path.EndsWith(".css") ||
            path.EndsWith(".svg") ||
            path.EndsWith(".ico")))
        {
            return Serilog.Events.LogEventLevel.Debug; 
        }

        if (ex != null || httpContext.Response.StatusCode >= 500)
        {
            return Serilog.Events.LogEventLevel.Error;
        }

        return Serilog.Events.LogEventLevel.Information;
    };
});

if (app.Environment.IsDevelopment())
{
   app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("ERP API Documentation")
               .WithTheme(ScalarTheme.Purple)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
               .WithOpenApiRoutePattern("/openapi/v1.json");
               
        options.AddPreferredSecuritySchemes(new[] { "Bearer" }); 
    });
    
}

app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesService.SeedRolesAsync(services);
}

app.Run();

