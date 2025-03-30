using System;
using System.Threading.Tasks;

namespace UserManagement.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
    Task RollbackAsync();
}