using ERP.Infrastructure.Shared;
using ERP.Api.Middlewares;
using QuestPDF;
using QuestPDF.Infrastructure;
using Serilog;
using Scalar.AspNetCore;

using ERP.Api.shared;
using System.Threading.Channels;
using ERP.Infrastructure.Shared.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

var environment = builder.Environment;

Settings.License = LicenseType.Community;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddApiServiceRegistration(builder.Configuration, environment);

builder.Host.UseSerilog((context, services, configuration) => configuration
              .ReadFrom.Configuration(context.Configuration)
              .ReadFrom.Services(services));

var options = new BoundedChannelOptions(capacity: 1000)
{
    FullMode = BoundedChannelFullMode.Wait, 
    SingleWriter = false,                 
    SingleReader = false                 
};





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
app.MapHub<NotificationHub>("/hubs/notifications");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesService.SeedRolesAsync(services);
}
app.Run();

