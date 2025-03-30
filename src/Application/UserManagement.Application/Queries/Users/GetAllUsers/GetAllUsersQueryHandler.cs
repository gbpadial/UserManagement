using MediatR;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Queries.Users.GetAllUsers;

public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
{
    public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetListAsync(request.Page, (request.Page + 1) * request.Size);

        var mappedResult = result.Data.Select(UserDto.FromEntity);

        return new GetAllUsersResponse
        {
            Data = mappedResult,
            TotalRecords = result.TotalRecords,
            CurrentPage = request.Page + 1,
            Size = request.Size
        };
    }
}
