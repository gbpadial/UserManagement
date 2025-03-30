using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Infra.Repositories;
using UserManagement.Infra.Repositories.Users;

namespace UserManagement.Infra.Setup.Installers;

public static class RepositoryInstaller
{
    public static IServiceCollection InstallRepositories(this IServiceCollection services) => services
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IUserRepository, UserRepository>();
}
