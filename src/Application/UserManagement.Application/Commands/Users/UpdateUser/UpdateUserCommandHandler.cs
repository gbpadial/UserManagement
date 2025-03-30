using MediatR;
using UserManagement.Application.Common.Exceptions;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;

namespace UserManagement.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler(
    IUserRepository repository,
    ICepService cepService,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = repository.GetById(request.Id)
            ?? throw new AppException($"A user with Id {request.Id} was not found.");

        if (request.ZipCode != null && !user.ZipCode.Equals(request.ZipCode))
        {
            user.ZipCode = request.ZipCode;
            var cepResponse = await cepService.GetAsync(request.ZipCode);
            user.Address = cepResponse?.Street;
        }

        user.Name = request.Name ?? user.Name;
        user.Password = request.Password ?? user.Password;

        repository.Update(user);
        await unitOfWork.CommitAsync();

        return UserDto.FromEntity(user);
    }
}