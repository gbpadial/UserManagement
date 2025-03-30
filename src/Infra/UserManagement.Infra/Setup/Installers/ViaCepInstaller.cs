using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using UserManagement.Domain.Services;
using UserManagement.Infra.HttpClients;
using UserManagement.Infra.Services;

namespace UserManagement.Infra.Setup.Installers;

public static class ViaCepInstaller
{
    public static void InstallViaCepService(this IServiceCollection services) => services
        .AddTransient<ICepService, ViaCepService>()
        .AddRefitClient<IViaCepClient>()
        .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://viacep.com.br/"));
}
