using FluentValidation;
using UserManagement.Application.Queries.Users.GetUserByEmail;

namespace UserManagement.Application.Validations.Users;

public class GetUserByEmailRequestValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailRequestValidator()
        => RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("The e-mail can't be null")
            .EmailAddress()
            .WithMessage("The e-mail must be valid");
}
