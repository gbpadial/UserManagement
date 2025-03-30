using UserManagement.Domain.Entities.Persons;

namespace UserManagement.Domain.Entities.Users;

public class User(
    string name,
    string postalCode,
    string? address,
    string email,
    string password)
    : Person(name, postalCode, address)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}
