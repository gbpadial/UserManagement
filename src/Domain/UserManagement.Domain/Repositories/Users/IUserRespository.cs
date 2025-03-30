using UserManagement.Domain.Entities.Users;

namespace UserManagement.Domain.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    User? GetByEmail(string email);
}
