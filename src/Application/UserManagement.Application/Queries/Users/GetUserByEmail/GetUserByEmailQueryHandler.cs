using MediatR;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Queries.Users.GetUserByEmail;

public class GetUserByEmailQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = repository.GetByEmail(request.Email);
        if (user == null)
        {
            return Task.FromResult(new UserDto());
        }

        var response = UserDto.FromEntity(user);

        return Task.FromResult(response);
    }
}
