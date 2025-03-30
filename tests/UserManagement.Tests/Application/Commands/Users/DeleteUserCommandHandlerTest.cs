using Moq.AutoMock;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Application.Commands.Users.DeleteUser;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Tests.Application.MockBuilders.Commands;
using UserManagement.Tests.Domain.Entities.MockBuilders;

namespace UserManagement.Tests.Application.Commands.Users;

public class DeleteUserCommandHandlerTest
{
    private readonly AutoMocker _mocker = new();
    private readonly DeleteUserCommandHandler _handler;

    public DeleteUserCommandHandlerTest()
        => _handler = _mocker.CreateInstance<DeleteUserCommandHandler>();

    [Fact]
    public async Task Handle_WithAllValidData_ShouldReturnTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = new UserMockBuilder()
            .RuleFor(x => x.Id, id)
            .Generate();

        var command = new DeleteUserCommandMockBuilder()
            .RuleFor(x => x.Id, id)
            .Generate();

        SetupCommitAsync();
        SetupRepositoryGetById(id, user);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedDeleteUserDto = new DeleteUserDto(true);

        result.ShouldBeEquivalentTo(expectedDeleteUserDto);
    }

    [Fact]
    public async Task Handle_WhenUserWasNotFound_ShouldReturnFalse()
    {
        // Arrange
        var command = new DeleteUserCommandMockBuilder()
            .Generate();

        SetupRepositoryGetById(command.Id, null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedDeleteUserDto = new DeleteUserDto(false);

        result.ShouldBeEquivalentTo(expectedDeleteUserDto);
    }

    [Fact]
    public async Task Handle_WhenCommitAsyncFails_ShouldReturnFalse()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = new UserMockBuilder()
            .RuleFor(x => x.Id, id)
            .Generate();

        var command = new DeleteUserCommandMockBuilder()
            .RuleFor(x => x.Id, id)
            .Generate();

        SetupCommitAsync(0);
        SetupRepositoryGetById(id, user);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var expectedDeleteUserDto = new DeleteUserDto(false);

        result.ShouldBeEquivalentTo(expectedDeleteUserDto);
    }

    private void SetupRepositoryGetById(Guid id, User? user)
        => _mocker.GetMock<IUserRepository>()
            .Setup(rep => rep.GetById(It.Is<Guid>(x => x == id)))
            .Returns(user);

    private void SetupCommitAsync(int result = 1)
        => _mocker.GetMock<IUnitOfWork>()
            .Setup(w => w.CommitAsync())
            .ReturnsAsync(result);
}
