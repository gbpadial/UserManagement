using Bogus;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Tests.Domain.Entities.MockBuilders;

internal class UserMockBuilder : Faker<User>
{
    public UserMockBuilder()
        => CustomInstantiator(f => new(
            f.Person.FullName,
            f.Address.ZipCode("########"),
            f.Address.StreetAddress(),
            f.Person.Email,
            f.Random.String(10)));
}