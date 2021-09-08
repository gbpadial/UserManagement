using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.UpdateUser;
using UserManagement.Domain.Errors;
using UserManagement.Domain.Models.Cep;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;

namespace UserManagement.Domain.Handlers.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _repository;
        private readonly ICepService _cepService;

        public UpdateUserCommandHandler(IUserRepository repository, ICepService cepService)
        {
            _repository = repository;
            _cepService = cepService;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            if (user == null)
            {
                throw new NotFoundException($"Não foi encontrado um usuário com o Id {request.Id}");
            }
            if (request.Cep != null && !user.Cep.Equals(request.Cep))
            {
                user.Cep = request.Cep;
                CepModel retorno = await _cepService.Get(request.Cep);
                if (retorno != null)
                {
                    user.Logradouro = _cepService.FormatLogradouroFromCepModel(retorno); 
                }
            }
            user.Nome = request.Nome != null ? request.Nome : user.Nome;
            user.Senha = request.Senha != null ? request.Senha : user.Senha;
            _repository.Update(user);

            return new UpdateUserResponse
            {
                Id = user.Id.ToString(),
                Cep = user.Cep,
                Email = user.Email,
                Logradouro = user.Logradouro,
                Nome = user.Nome
            };
        }
    }
}
