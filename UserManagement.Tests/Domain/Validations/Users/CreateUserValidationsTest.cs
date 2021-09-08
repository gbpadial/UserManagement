using FluentValidation.Results;
using Moq;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Validations.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Validations.Users
{
    public class CreateUserValidationsTest
    {
        
        [Fact(DisplayName = "Invalid CEP: null")]
        public void InvalidCep()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = null,
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Invalid CEP: 8903600")]
        public void InvalidCepMinLenght()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "8903600",
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Invalid CEP: 89036001232")]
        public void InvalidCepMaxLenght()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89036001232",
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Valid e-mail: teste@teste.com")]
        public void ValidEmail()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89030016",
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Invalid e-mail: teste@")]
        public void InvalidEmail()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89030016",
                Email = "teste@",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Invalid e-mail: teste")]
        public void InvalidEmailWithoutAtSymbol()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89030016",
                Email = "teste",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Invalid Nome: Empty")]
        public void EmptyNome()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89030016",
                Email = "teste",
                Nome = "",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Invalid Senha: Empty")]
        public void EmptySenha()
        {

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns<User>(null);
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89030016",
                Email = "teste",
                Nome = "Teste",
                Senha = ""
            };

            ValidationResult result = validator.Validate(request);
            Assert.False(result.IsValid);
        }
    }
}
