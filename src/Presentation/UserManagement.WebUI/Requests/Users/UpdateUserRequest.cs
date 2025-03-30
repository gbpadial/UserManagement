using System;
using UserManagement.Application.Commands.Users.UpdateUser;

namespace UserManagement.WebUI.Requests.Users;

public record UpdateUserRequest(
    string Email,
    string Password,
    string Name,
    string ZipCode)
{
    public UpdateUserCommand ToCommand(Guid id)
        => new(id, Email, Password, Name, ZipCode);
}
