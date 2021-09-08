using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Entities.Pessoas
{
    public abstract class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
    }
}
