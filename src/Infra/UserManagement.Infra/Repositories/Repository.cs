using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Domain.Common;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infra.Repositories;

public abstract class Repository<T>(UserManagementContext apiContext) : IRepository<T> where T : class
{
    protected UserManagementContext ApiContext => apiContext;

    public virtual async Task AddAsync(T entity)
        => await apiContext.Set<T>().AddAsync(entity);

    public virtual void Delete(T entity)
        => apiContext.Set<T>().Remove(entity);

    public virtual async Task<PaginatedResultData<T>> GetListAsync(int skip, int take)
    {
        var totalRecords = apiContext.Set<T>().Count();

        var data = await apiContext.Set<T>()
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return new PaginatedResultData<T>(data, totalRecords);
    }

    public virtual T? GetById(Guid id)
        => apiContext.Set<T>().Find(id);

    public virtual void Update(T entity)
        => apiContext.Set<T>().Update(entity);
}
