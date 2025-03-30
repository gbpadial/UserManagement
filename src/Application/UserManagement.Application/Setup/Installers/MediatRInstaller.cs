using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Application.Setup.Installers;

public static class MediatRInstaller
{
    public static IServiceCollection InstallMediatR(this IServiceCollection services)
        => services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(MediatRInstaller).Assembly));
}
