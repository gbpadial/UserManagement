using MediatR;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Application.Commands.Users.CreateUser;

public record CreateUserCommand(
    string Email,
    string Password,
    string Name,
    string ZipCode) : IRequest<UserDto>;