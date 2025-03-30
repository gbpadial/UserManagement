using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Persons;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Infra;

public class UserManagementContext(DbContextOptions<UserManagementContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Pessoas { get; set; }
}
