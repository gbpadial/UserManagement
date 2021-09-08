using System.Collections.Generic;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Domain.Queries.Users.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public IEnumerable<User> Users { get; set; }
    }
}
