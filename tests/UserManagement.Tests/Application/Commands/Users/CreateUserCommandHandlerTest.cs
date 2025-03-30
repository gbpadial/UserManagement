using Moq.AutoMock;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Application.Commands.Users.CreateUser;
using UserManagement.Domain.Models.Address;
using UserManagement.Domain.Services;
using UserManagement.Tests.Application.MockBuilders.Commands;
using UserManagement.Tests.Application.MockBuilders.Dtos;
using UserManagement.Tests.Domain.Models.MockBuilders;

namespace UserManagement.Tests.Application.Commands.Users;

public class CreateUserCommandHandlerTest
{
    private readonly AutoMocker _mocker = new();
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTest()
        => _handler = _mocker.CreateInstance<CreateUserCommandHandler>();

    [Fact]
    public async Task Handle_WithAllValidData_ShouldReturnTheUserCreated()
    {
        // Arrange
        var address = new AddressModelMockBuilder().Generate();
        var zipCode = "12345678";

        var command = new CreateUserCommandMockBuilder()
            .RuleFor(x => x.ZipCode, zipCode)
            .Generate();

        SetupCepServiceGetAsync(zipCode, address);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedUserDto = new UserDtoMockBuilder()
            .RuleFor(x => x.Id, result.Id)
            .RuleFor(x => x.Address, address.Street)
            .RuleFor(x => x.Email, command.Email)
            .RuleFor(x => x.ZipCode, zipCode)
            .RuleFor(x => x.Name, command.Name)
            .Generate();

        result.ShouldBeEquivalentTo(expectedUserDto);
    }

    [Fact]
    public async Task Handle_WithCepReturningNull_ShouldReturnTheUserCreatedWithNullAddress()
    {
        // Arrange
        var zipCode = "12345678";

        var command = new CreateUserCommandMockBuilder()
            .RuleFor(x => x.ZipCode, zipCode)
            .Generate();

        SetupCepServiceGetAsync(zipCode, null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedUserDto = new UserDtoMockBuilder()
            .RuleFor(x => x.Id, result.Id)
            .RuleFor(x => x.Address, (string?)null)
            .RuleFor(x => x.Email, command.Email)
            .RuleFor(x => x.ZipCode, zipCode)
            .RuleFor(x => x.Name, command.Name)
            .Generate();

        result.ShouldBeEquivalentTo(expectedUserDto);
    }

    private void SetupCepServiceGetAsync(string zipCode, AddressModel? model)
        => _mocker.GetMock<ICepService>()
            .Setup(x => x.GetAsync(It.Is<string>(a => a == zipCode)))
            .ReturnsAsync(model);

}
