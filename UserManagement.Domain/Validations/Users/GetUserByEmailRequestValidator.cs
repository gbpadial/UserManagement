using FluentValidation;
using UserManagement.Domain.Queries.Users.GetUserByEmail;

namespace UserManagement.Domain.Validations.Users
{
    public class GetUserByEmailRequestValidator : AbstractValidator<GetUserByEmailRequest>
    {
        public GetUserByEmailRequestValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("O Email não pode ser nulo")
                .EmailAddress()
                .WithMessage("O Email não é válido");
        }
    }
}
