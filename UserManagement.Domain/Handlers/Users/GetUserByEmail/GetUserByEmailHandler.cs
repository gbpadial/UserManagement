using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Queries.Users.GetUserByEmail;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Handlers.Users.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailRequest, GetUserByEmailResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<GetUserByEmailResponse> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            User user = _repository.GetByEmail(request.Email);
            if (user == null)

            {
                return Task.FromResult(new GetUserByEmailResponse());
            }

            var response = new GetUserByEmailResponse
            {
                Cep = user.Cep,
                Id = user.Id.ToString(),
                Email = user.Email,
                Logradouro = user.Logradouro,
                Nome = user.Nome
            };
            return Task.FromResult(response);
        }
    }
}
