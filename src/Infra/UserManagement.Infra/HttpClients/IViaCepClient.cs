using Refit;
using System.Threading.Tasks;
using UserManagement.Domain.Models.Address;

namespace UserManagement.Infra.HttpClients;

public interface IViaCepClient
{
    [Get("/ws/{cep}/json/")]
    Task<IApiResponse<AddressModel>> GetCepAsync(string cep);
}
