using System.Threading.Tasks;
using UserManagement.Domain.Models.Cep;

namespace UserManagement.Domain.Services
{
    public interface ICepService
    {
        Task<CepModel> Get(string cep);
        string FormatLogradouroFromCepModel(CepModel cep);
    }
}
