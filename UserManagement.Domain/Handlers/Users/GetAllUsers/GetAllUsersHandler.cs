using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Queries.Users.GetAllUsers;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Domain.Handlers.Users.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        protected readonly IUserRepository _repository;

        public GetAllUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.GetListAsync(request.Skip, request.Take);
            GetAllUsersResponse response = new GetAllUsersResponse
            {
                Users = result
            };
            return Task.FromResult(response);
        }
    }
}
