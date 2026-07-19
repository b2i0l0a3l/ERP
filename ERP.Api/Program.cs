using ERP.Application.Shared;
using ERP.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

IConfiguration configuration = builder.Configuration; 
builder.Services.AddInfrastructurServiceRegistration(configuration);
builder.Services.AddApplicationServiceRegistration();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

