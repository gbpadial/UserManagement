using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace UserManagement.WebUI.Core.Setup.Installers;

public static class SwaggerInstaller
{
    public static IServiceCollection InstallSwagger(this IServiceCollection services) => services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

            options.IncludeXmlComments(xmlPath);

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "User Management API",
                Version = "v1",
                Description = "An API for managing users"
            });
        });
}
