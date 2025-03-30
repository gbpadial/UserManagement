using MediatR;
using UserManagement.Application.Dtos.Users;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Commands.Users.DeleteUser;

public class DeleteUserCommandHandler(
    IUserRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, DeleteUserDto>
{
    public async Task<DeleteUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = repository.GetById(request.Id);
        bool deletedSuccessful = false;
        if (user != null)
        {
            repository.Delete(user);
            deletedSuccessful = await unitOfWork.CommitAsync() > 0;
        }

        return new DeleteUserDto(deletedSuccessful);
    }
}