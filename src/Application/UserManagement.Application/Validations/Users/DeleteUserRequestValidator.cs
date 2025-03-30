using FluentValidation;
using UserManagement.Application.Commands.Users.DeleteUser;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Validations.Users;

public class DeleteUserRequestValidator : AbstractValidator<DeleteUserCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserRequestValidator(IUserRepository repository)
    {
        _repository = repository;
        RuleFor(u => u.Id)
            .Must(UserExistsForDelete)
            .WithMessage("The informed user doesn't exists");
    }

    private bool UserExistsForDelete(Guid id)
    {
        if (_repository.GetById(id) == null)
        {
            return false;
        }
        return true;
    }
}