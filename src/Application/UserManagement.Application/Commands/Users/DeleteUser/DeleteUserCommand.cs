using MediatR;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Application.Commands.Users.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserDto>;