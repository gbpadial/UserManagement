using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Handlers.Users.GetUserByEmail;
using UserManagement.Domain.Queries.Users.GetUserByEmail;
using UserManagement.Domain.Repositories.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Handlers.Users
{
    public class GetUserByEmailHandlerTest
    {
        [Fact(DisplayName = "Must return a user with email")]
        public async Task GetUserWithEmail()
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

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(user);

            GetUserByEmailHandler handler = new GetUserByEmailHandler(userRepository.Object);
            GetUserByEmailRequest request = new GetUserByEmailRequest
            {
                Email = "teste@teste.com"
            };

            GetUserByEmailResponse response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Equal("teste@teste.com", response.Email);
            Assert.Equal("89036001", response.Cep);
            Assert.Equal("ua as asas", response.Logradouro);
        }

        [Fact(DisplayName = "Didn't found an user with email")]
        public async Task DidntGetUserWithEmail()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);

            GetUserByEmailHandler handler = new GetUserByEmailHandler(userRepository.Object);
            GetUserByEmailRequest request = new GetUserByEmailRequest
            {
                Email = "teste@teste.com"
            };

            GetUserByEmailResponse response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Null(response.Id);
        }

        [Fact(DisplayName = "Must thrown an Exception")]
        public async Task GetByEmailThrowsException()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Throws<Exception>();

            GetUserByEmailHandler handler = new GetUserByEmailHandler(userRepository.Object);
            GetUserByEmailRequest request = new GetUserByEmailRequest
            {
                Email = "teste@teste.com"
            };
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, new System.Threading.CancellationToken()));
        }
    }
}
