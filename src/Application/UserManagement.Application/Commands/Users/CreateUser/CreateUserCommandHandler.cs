using MediatR;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;

namespace UserManagement.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ICepService cepService) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var cepResponse = await cepService.GetAsync(request.ZipCode);

        var user = new User(
            request.Name,
            request.ZipCode,
            cepResponse?.Street,
            request.Email,
            request.Password);

        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();

        return UserDto.FromEntity(user);
    }
}
