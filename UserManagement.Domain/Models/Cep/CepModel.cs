using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Models.Cep
{
    public class CepModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
    }
}
