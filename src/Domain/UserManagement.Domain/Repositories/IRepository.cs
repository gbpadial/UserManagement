using System;
using System.Threading.Tasks;
using UserManagement.Domain.Common;

namespace UserManagement.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<PaginatedResultData<T>> GetListAsync(int skip, int take);
    Task AddAsync(T entity);
    T? GetById(Guid id);
    void Delete(T entity);
    void Update(T entity);
}
