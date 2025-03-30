using MediatR;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Application.Commands.Users.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    string Email,
    string Password,
    string Name,
    string ZipCode) : IRequest<UserDto>;