using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using UserManagement.Application.Setup.Installers;
using UserManagement.Application.Validations;
using UserManagement.Infra.Setup.Installers;
using UserManagement.WebUI.Core.Setup.Installers;
using UserManagement.WebUI.Setup.Installers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.InstallValidations();
builder.Services.InstallDbContext();
builder.Services.InstallViaCepService();
builder.Services.InstallRepositories();
builder.Services.InstallMediatR();
builder.Services.InstallSwagger();
builder.Services.InstallMiddlewares();

builder.Services.AddControllers();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();