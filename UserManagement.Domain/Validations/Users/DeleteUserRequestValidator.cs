using FluentValidation;
using UserManagement.Domain.Commands.Users.DeleteUser;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Validations.Users
{
    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        private readonly IUserRepository _repository;

        public DeleteUserRequestValidator(IUserRepository repository)
        {
            _repository = repository;
            RuleFor(u => u.Email)
                .Must(UserExistsForDelete)
                .WithMessage("O usuário informado não existe para exclusão");
        }

        private bool UserExistsForDelete(string email)
        {
            if (_repository.GetByEmail(email) == null)
            {
                return false;
            }
            return true;
        }
    }
}
