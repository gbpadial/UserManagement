using UserManagement.Application.Common.Queries;

namespace UserManagement.Application.Queries.Users.GetAllUsers;

public record GetAllUsersQuery(int Page, int Size)
    : PaginatedQuery<GetAllUsersResponse>(Page, Size)
{ }