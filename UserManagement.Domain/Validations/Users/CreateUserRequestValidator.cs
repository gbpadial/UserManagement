using FluentValidation;
using UserManagement.Domain.Commands.Users.CreateUser;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Validations.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IUserRepository _repository;

        public CreateUserRequestValidator(IUserRepository repository)
        {
            _repository = repository;
            RuleFor(u => u.Cep)
                .NotEmpty().WithMessage("O CEP deve ser informado")
                .MinimumLength(8).WithMessage("O CEP deve possui 8 caracteres")
                .MaximumLength(8).WithMessage("O CEP deve possui 8 caracteres");
            RuleFor(u => u.Email)
                .Must(MustHaveOnlyOneUserWithEmail).WithMessage("Usuário já cadastrado com este e-mail")
                .NotEmpty().WithMessage("O Email deve ser informado")
                .EmailAddress().WithMessage("O Email deve ser válido");
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O Nome deve ser informado");
            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A Senha deve ser informada");
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
}

