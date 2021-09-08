using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Handlers.Users.GetAllUsers;
using UserManagement.Domain.Queries.Users.GetAllUsers;
using UserManagement.Domain.Repositories.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Handlers.Users
{
    public class GetAllUsersHandlerTest
    {
        [Fact(DisplayName = "Must return 2 users")]
        public async Task GetAllUsers()
        {
            IList<User> users = new List<User>();
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                Cep = "89036001",
                Email = "teste@teste.com",
                Logradouro = "ua as asas",
                Nome = "Testes",
                Senha = "1234"
            });

            users.Add(new User
            {
                Id = Guid.NewGuid(),
                Cep = "89030016",
                Email = "testes@testes.com",
                Logradouro = "ua as asas as ortas",
                Nome = "Testes Dois",
                Senha = "12345"
            });

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetListAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(users);

            GetAllUsersHandler handler = new GetAllUsersHandler(userRepository.Object);
            GetAllUsersRequest request = new GetAllUsersRequest
            {
                Skip = 0,
                Take = 10
            };

            GetAllUsersResponse response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(response.Users);

            List<User> list = (response.Users as List<User>);
            Assert.True(list.Count == 2);

        }

        [Fact(DisplayName = "Must throw an exception")]
        public async Task GetAllUsersWithException()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetListAsync(It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception());

            GetAllUsersHandler handler = new GetAllUsersHandler(userRepository.Object);
            GetAllUsersRequest request = new GetAllUsersRequest
            {
                Skip = 0,
                Take = 10
            };
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, new System.Threading.CancellationToken()));
        }
    }
}
