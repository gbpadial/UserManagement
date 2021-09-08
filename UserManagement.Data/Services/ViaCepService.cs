using System.Net.Http;
using System.Threading.Tasks;
using UserManagement.Core.Http;
using UserManagement.Domain.Models.Cep;
using UserManagement.Domain.Services;

namespace UserManagement.Data.Services
{
    public class ViaCepService : ICepService
    {
        private const string VIA_CEP_URL = @"https://viacep.com.br/ws/{0}/json/";
        private readonly IHttpHandler _client;

        public ViaCepService(IHttpHandler client)
        {
            _client = client;
        }

        public string FormatLogradouroFromCepModel(CepModel cep)
        {
            if (!string.IsNullOrEmpty(cep.Logradouro))
            {
                return RemoveFirstCharFromString(cep.Logradouro);
            }
            return "";
        }

        private string RemoveFirstCharFromString(string value)
        {
            string[] words = value.Split(' ');
            string result = "";
            foreach(string word in words)
            {
                result += $"{word.Substring(1, word.Length-1)} ";
            }
            return result.Trim();
        }

        public virtual async Task<CepModel> Get(string cep)
        {
            string path = string.Format(VIA_CEP_URL, cep);
            HttpResponseMessage response = await _client.GetAsync(path);
            CepModel retorno = null;
            if (response.IsSuccessStatusCode)
            {
                retorno = await response.Content.ReadAsAsync<CepModel>();
            }
            return retorno;
        }
    }
}
