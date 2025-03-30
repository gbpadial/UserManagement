using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.WebUI.Middlewares;

namespace UserManagement.WebUI.Setup.Installers;

public static class MiddewareInstaller
{
    public static IServiceCollection InstallMiddlewares(this IServiceCollection services)
        => services.AddSingleton<ErrorHandlingMiddleware>();

    public static IApplicationBuilder UseMiddlewares(this WebApplication app)
        => app.UseMiddleware<ErrorHandlingMiddleware>();
}
