using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Repositories
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetListAsync(int skip, int take);
        Task AddAsync(T entity);
        T GetById(Guid id);
        void Delete(T entity);
        void Update(T entity);
    }
}
