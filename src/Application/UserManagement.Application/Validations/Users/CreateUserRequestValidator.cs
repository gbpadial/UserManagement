using FluentValidation;
using UserManagement.Application.Commands.Users.CreateUser;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Validations.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IUserRepository _repository;

    public CreateUserRequestValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(u => u.ZipCode)
            .NotEmpty().WithMessage("The zip code code must be informed")
            .Must(x => x.Length == 8).WithMessage("The zip code code must have 8 characters");

        RuleFor(u => u.Email)
            .Must(MustHaveOnlyOneUserWithEmail).WithMessage("There's already an user with this e-mail")
            .NotEmpty().WithMessage("The e-mail must be informed")
            .EmailAddress().WithMessage("The e-mail must be valid");

        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("The name must be informed");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("The password must be informed");
    }

    private bool MustHaveOnlyOneUserWithEmail(string email)
    {
        if (_repository.GetByEmail(email) != null)
        {
            return false;
        }

        return true;
    }
}