using System.Linq;
using UserManagement.Domain;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Infra.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiContext apiContext) : base(apiContext) { }

        public User GetByEmail(string email)
        {
            return _apiContext.Set<User>().FirstOrDefault(x => x.Email.ToLower().Equals(email));
        }
    }
}
