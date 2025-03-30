using Bogus;
using System;
using UserManagement.Application.Commands.Users.DeleteUser;

namespace UserManagement.Tests.Application.MockBuilders.Commands;

public class DeleteUserCommandMockBuilder : Faker<DeleteUserCommand>
{
    public DeleteUserCommandMockBuilder()
        => CustomInstantiator(f => new(Guid.NewGuid()));
}
