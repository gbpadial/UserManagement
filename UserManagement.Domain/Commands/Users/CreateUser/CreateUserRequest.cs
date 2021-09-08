using MediatR;

namespace UserManagement.Domain.Commands.Users.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
    }
}
