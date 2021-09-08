using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Domain;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApiContext _apiContext;

        public Repository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _apiContext.Set<T>().AddAsync(entity);
            await _apiContext.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            _apiContext.Set<T>().Remove(entity);
            _apiContext.SaveChanges();
        }

        public virtual IEnumerable<T> GetListAsync(int skip, int take)
        {
            return _apiContext.Set<T>()
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public virtual T GetById(Guid id)
        {
            return _apiContext.Set<T>().Find(id);
                
        }

        public virtual void Update(T entity)
        {
            _apiContext.Set<T>()
                .Update(entity);
            _apiContext.SaveChanges();
        }
    }
}
