using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.DeleteUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Handlers.Users.DeleteUser;
using UserManagement.Domain.Handlers.Users.GetUserByEmail;
using UserManagement.Domain.Queries.Users.GetUserByEmail;
using UserManagement.Domain.Repositories.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Handlers.Users
{
    public class DeleteUserCommandHandlerTest
    {
        [Fact(DisplayName = "Exclude user successfully")]
        public async Task ExcludeUserSuccessfully()
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
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(user) ;

            DeleteUserCommandHandler handler = new DeleteUserCommandHandler(userRepository.Object);
            DeleteUserRequest request = new DeleteUserRequest
            {
                Email = "teste@teste.com"
            };

            var response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.True(response.Deleted);
        }

        [Fact(DisplayName = "Didnt found user to delete")]
        public async Task DidntFoundUserToDelete()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);

            DeleteUserCommandHandler handler = new DeleteUserCommandHandler(userRepository.Object);
            DeleteUserRequest request = new DeleteUserRequest
            {
                Email = "teste@teste.com"
            };

            var response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.False(response.Deleted);
        }
    }
}
