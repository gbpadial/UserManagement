using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Models.Cep;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;

namespace UserManagement.Domain.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        protected readonly IUserRepository _userRepository;
        protected readonly ICepService _cepService;

        public CreateUserCommandHandler(IUserRepository userRepository, ICepService cepService)
        {
            _userRepository = userRepository;
            _cepService = cepService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                Senha = request.Senha,
                Cep = request.Cep,
                Nome = request.Nome
            };

            CepModel retorno = await _cepService.Get(request.Cep);
            if (retorno != null)
            {
                user.Logradouro = _cepService.FormatLogradouroFromCepModel(retorno);
            }

            await _userRepository.AddAsync(user);
            return new CreateUserResponse
            {
                Cep = user.Cep,
                Email = user.Email,
                Logradouro = user.Logradouro,
                Nome = user.Nome,
                Id = user.Id.ToString()
            };
        }

    }
}
