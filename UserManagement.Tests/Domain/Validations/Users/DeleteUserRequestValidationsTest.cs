using FluentValidation.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Commands.Users.DeleteUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Validations.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Validations.Users
{
    public class DeleteUserRequestValidationsTest
    {
        [Fact(DisplayName = "Didn't found a user to delete")]
        public void DidntFoundUserToDelete()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            DeleteUserRequestValidator validator = new DeleteUserRequestValidator(userRepository.Object);

            DeleteUserRequest request = new DeleteUserRequest
            {
                Email = "teste@teste.com",
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Found a user to delete")]
        public void FoundUserToDelete()
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
            DeleteUserRequestValidator validator = new DeleteUserRequestValidator(userRepository.Object);

            DeleteUserRequest request = new DeleteUserRequest
            {
                Email = "teste@teste.com",
            };

            ValidationResult result = validator.Validate(request);
            Assert.True(result.IsValid);
        }
    }
}
