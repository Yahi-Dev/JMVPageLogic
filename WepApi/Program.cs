using JMVPageLogic.Core.Application.IOC;
using JMVPageLogic.Infrastructure.Identity.IOC;
using JMVPageLogic.Infrastructure.Shared.IOC;
using WepApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.IdentityLayerRegistration(builder.Configuration);
builder.Services.PersistenceLayerRegistration(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.ApplicationLayerRegistration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
