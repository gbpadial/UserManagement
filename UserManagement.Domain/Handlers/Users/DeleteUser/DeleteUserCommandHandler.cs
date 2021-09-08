using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Commands.Users.DeleteUser;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Handlers.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        protected readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            User user = _repository.GetByEmail(request.Email);
            DeleteUserResponse response = new DeleteUserResponse();
            if (user != null)
            {
                _repository.Delete(user);
                response.Deleted = true;
            }
            else
            {
                response.Deleted = false;
            }
            return Task.FromResult(response); 
        }
    }
}
