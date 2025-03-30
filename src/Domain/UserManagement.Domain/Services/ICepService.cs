using System.Threading.Tasks;
using UserManagement.Domain.Models.Address;

namespace UserManagement.Domain.Services;

public interface ICepService
{
    Task<AddressModel?> GetAsync(string cep);
}
