using UserManagement.Application.Commands.Users.CreateUser;

namespace UserManagement.WebUI.Requests.Users;

public record CreateUserRequest(
    string Email,
    string Password,
    string Name,
    string ZipCode)
{
    public CreateUserCommand ToCommand()
        => new(Email, Password, Name, ZipCode);
};
