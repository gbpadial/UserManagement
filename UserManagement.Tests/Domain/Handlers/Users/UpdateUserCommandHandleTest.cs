using FluentValidation.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Commands.Users.UpdateUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Handlers.Users.UpdateUser;
using UserManagement.Domain.Models.Cep;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;
using UserManagement.Domain.Validations.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Handlers.Users
{
    public class UpdateUserCommandHandleTest
    {
        [Fact]
        public async Task UpdateUser()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Cep = "89036001",
                Email = "teste@teste.com",
                Logradouro = "ua as asas",
                Nome = "Testes",
                Senha = "1234"
            };

            CepModel cep = new CepModel
            {
                Bairro = "Velha",
                Cep = "89036001",
                Ibge = "1234",
                Localidade = "Blumenau",
                Logradouro = "Rua João Pessoa"
            };

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(user);

            Mock<ICepService> cepService = new Mock<ICepService>();
            cepService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(cep);
            cepService.Setup(x => x.FormatLogradouroFromCepModel(It.IsAny<CepModel>())).Returns("ua oão essoa");

            UpdateUserCommandHandler handler = new UpdateUserCommandHandler(userRepository.Object, cepService.Object);
            UpdateUserRequest request = new UpdateUserRequest
            {
                Id = Guid.NewGuid(),
                Cep = "89036270",
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };
            
            UpdateUserResponse response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Equal("ua oão essoa", response.Logradouro);
        }
    }
}
