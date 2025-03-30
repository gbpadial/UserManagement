using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Application.Setup.Installers;

public static class ValidationInstaller
{
    public static IServiceCollection InstallValidations(this IServiceCollection services)
        => services.AddValidatorsFromAssemblyContaining(typeof(ValidationInstaller));
}
