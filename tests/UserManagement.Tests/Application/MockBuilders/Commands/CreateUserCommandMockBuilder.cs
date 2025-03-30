using Bogus;
using UserManagement.Application.Commands.Users.CreateUser;

namespace UserManagement.Tests.Application.MockBuilders.Commands;

public class CreateUserCommandMockBuilder : Faker<CreateUserCommand>
{
    public CreateUserCommandMockBuilder()
        => CustomInstantiator(f => new(
            f.Person.Email,
            f.Random.String(10),
            f.Person.FullName,
            f.Address.ZipCode("########")));
}
