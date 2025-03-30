using FluentValidation;
using UserManagement.Application.Commands.Users.UpdateUser;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.Validations.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserCommand>
{
    private readonly IUserRepository _repository;

    public UpdateUserRequestValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(u => u.Id)
            .Must(UserMustExistsWIthId)
            .WithMessage("User was not found");

        RuleFor(u => new { u.Id, u.Email })
            .Must(x => RemainsTheSameEmail(x.Id, x.Email))
            .When(x => x.Email != null)
            .WithMessage("O Email não pode ser alterado");

        RuleFor(u => u.ZipCode)
            .NotEmpty()
            .When(x => x.ZipCode != null)
            .WithMessage("The zip code code must be informed")
            .Must(x => x.Length == 8)
            .When(x => x.ZipCode != null)
            .WithMessage("The zip code code deve possui 8 caracteres");

        RuleFor(u => u.Name)
            .NotEmpty()
            .When(x => x.Name != null)
            .WithMessage("The name must be informed");

        RuleFor(u => u.Password)
            .NotEmpty()
            .When(x => x.Password != null)
            .WithMessage("The password must be informed");
    }

    private bool RemainsTheSameEmail(Guid id, string email)
    {
        var user = _repository.GetById(id);
        if (user == null || !user.Email.Equals(email))
            return false;
        return true;
    }

    private bool UserMustExistsWIthId(Guid id)
    {
        if (_repository.GetById(id) == null)
            return false;
        return true;
    }
}
