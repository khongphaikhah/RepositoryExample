using RepositoryExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetFilter(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(int id);
    }
}
