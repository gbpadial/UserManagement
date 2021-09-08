using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities.Pessoas;

namespace UserManagement.Domain.Entities.Users
{
    public class User : Pessoa
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
