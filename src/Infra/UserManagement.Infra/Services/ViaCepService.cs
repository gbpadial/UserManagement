using System.Threading.Tasks;
using UserManagement.Domain.Models.Address;
using UserManagement.Domain.Services;
using UserManagement.Infra.Common.Exceptions;
using UserManagement.Infra.HttpClients;

namespace UserManagement.Infra.Services;

public class ViaCepService(IViaCepClient client) : ICepService
{
    public virtual async Task<AddressModel?> GetAsync(string postalCode)
    {
        var response = await client.GetCepAsync(postalCode);
        if (!response.IsSuccessStatusCode)
        {
            throw new InfraException(response.Error.Message);
        }
        return response.Content;
    }
}