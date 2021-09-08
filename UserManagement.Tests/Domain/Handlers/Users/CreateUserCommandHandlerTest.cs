using FluentValidation.Results;
using Moq;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Models.Cep;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;
using UserManagement.Domain.Validations.Users;
using Xunit;

namespace UserManagement.Tests.Domain.Handlers.Users
{
    public class CreateUserCommandHandlerTest
    {
                
        [Fact]
        public async Task CreateNewUser()
        {
            
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.AddAsync(It.IsAny<User>())).Returns(Task.FromResult(true));
            CreateUserRequestValidator validator = new CreateUserRequestValidator(userRepository.Object);

            CepModel cep = new CepModel
            {
                Bairro = "Velha",
                Cep = "89036001",
                Ibge = "1234",
                Localidade = "Blumenau",
                Logradouro = "Rua João Pessoa"
            };
                        
            Mock<ICepService> cepService = new Mock<ICepService>();
            cepService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(cep);
            cepService.Setup(x => x.FormatLogradouroFromCepModel(It.IsAny<CepModel>())).Returns("ua oão essoa");

            CreateUserCommandHandler handler = new CreateUserCommandHandler(userRepository.Object, cepService.Object);
            CreateUserRequest request = new CreateUserRequest
            {
                Cep = "89036270",
                Email = "teste@teste.com",
                Nome = "Testes",
                Senha = "1234"
            };

            ValidationResult result = validator.Validate(request);
            Assert.True(result.IsValid);

            CreateUserResponse response = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Equal("ua oão essoa", response.Logradouro);
        }
    }
}
