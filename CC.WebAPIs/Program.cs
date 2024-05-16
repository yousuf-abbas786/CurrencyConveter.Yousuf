using CC.DataServices.Configurations;
using CC.Shared.Abstractions;
using CC.Shared.Configurations;

using CC.WebAPIs.Infrastructure;

using Microsoft.AspNetCore.Diagnostics;

using Serilog;

using System.Runtime.CompilerServices;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddShared(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseExceptionHandler(o => { });
app.MapEndpoints();
app.Run();
