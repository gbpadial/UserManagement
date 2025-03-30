using System;
using System.Threading.Tasks;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Infra.Repositories;

public class UnitOfWork(UserManagementContext context) : IUnitOfWork
{
    private readonly UserManagementContext _context = context;

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    public Task RollbackAsync()
    {
        _context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }
}