using MediatR;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Application.Queries.Users.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<UserDto>;