using UserManagement.Application.Common.Dtos;
using UserManagement.Application.Dtos.Users;

namespace UserManagement.Application.Queries.Users.GetAllUsers;

public record GetAllUsersResponse : PaginatedDto<UserDto>;