using Bogus;
using UserManagement.Domain.Models.Address;

namespace UserManagement.Tests.Domain.Models.MockBuilders;

public class AddressModelMockBuilder : Faker<AddressModel>
{
    public AddressModelMockBuilder()
        => CustomInstantiator(f => new()
        {
            Code = f.Random.Number(1, 99999).ToString(),
            District = f.Random.Word(),
            City = f.Random.Word(),
            State = f.Address.State(),
            Street = f.Address.StreetAddress(),
            ZipCode = f.Address.ZipCode("########")
        });
}
