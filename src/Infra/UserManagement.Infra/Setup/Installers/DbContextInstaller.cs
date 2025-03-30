using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Infra.Setup.Installers;

public static class DbContextInstaller
{
    public static IServiceCollection InstallDbContext(this IServiceCollection services) => services
        .AddDbContext<UserManagementContext>(opt => opt.UseInMemoryDatabase("UserManagement", null));
}