using MediatR;

namespace UserManagement.Domain.Queries.Users.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<GetAllUsersResponse>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
