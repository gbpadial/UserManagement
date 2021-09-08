using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Commands.Users.UpdateUser
{
    public class UpdateUserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
    }
}
