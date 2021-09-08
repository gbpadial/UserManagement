using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Pessoas;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Domain
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
