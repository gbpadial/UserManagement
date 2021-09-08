using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Commands.Users.UpdateUser
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
    }
}
