using Bogus;
using System;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Tests.Application.MockBuilders.Dtos;

public class UserDtoMockBuilder : Faker<UserDto>
{
    public UserDtoMockBuilder()
        => CustomInstantiator(f => new(
            Guid.NewGuid(),
            f.Person.Email,
            f.Person.FullName,
            f.Address.ZipCode("########"),
            f.Address.StreetAddress()));
}
