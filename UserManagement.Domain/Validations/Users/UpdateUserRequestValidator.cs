using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Commands.Users.UpdateUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Validations.Users
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        private readonly IUserRepository _repository;

        public UpdateUserRequestValidator(IUserRepository repository)
        {
            _repository = repository;
            RuleFor(u => u.Id)
                .Must(UserMustExistsWIthId).WithMessage("Usuário inexistente");
            RuleFor(u => new { u.Id, u.Email })
                .Must(x => RemainsTheSameEmail(x.Id, x.Email))
                .When(x => x.Email != null)
                .WithMessage("O Email não pode ser alterado");
            RuleFor(u => u.Cep)
                .NotEmpty().WithMessage("O CEP deve ser informado")
                .When(x => x.Cep != null)
                .MinimumLength(8).WithMessage("O CEP deve possui 8 caracteres")
                .When(x => x.Cep != null)
                .MaximumLength(8).WithMessage("O CEP deve possui 8 caracteres")
                .When(x => x.Cep != null);
            RuleFor(u => u.Nome)
                .NotEmpty()
                .When(x => x.Nome != null)
                .WithMessage("O Nome deve ser informado");
            RuleFor(u => u.Senha)
                .NotEmpty()
                .When(x => x.Senha != null)
                .WithMessage("A Senha deve ser informada");
        }

        private bool RemainsTheSameEmail(Guid id, string email)
        {
            User user = _repository.GetById(id);
            if (user == null || !user.Email.Equals(email))
            {
                return false;
            }
            return true;
        }

        private bool UserMustExistsWIthId(Guid id)
        {
            if (_repository.GetById(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
