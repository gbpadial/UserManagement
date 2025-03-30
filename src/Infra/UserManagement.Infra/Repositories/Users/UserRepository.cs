using System.Linq;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Infra.Repositories.Users;

public class UserRepository(UserManagementContext apiContext) : Repository<User>(apiContext), IUserRepository
{
    public User? GetByEmail(string email)
        => ApiContext.Set<User>().FirstOrDefault(x => x.Email.ToLower().Equals(email));
}
