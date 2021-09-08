using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Domain.Commands.Users.CreateUser
{
    public class CreateUserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
    }
}
