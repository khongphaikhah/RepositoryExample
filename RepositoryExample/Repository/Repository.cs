using Microsoft.EntityFrameworkCore;
using RepositoryExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext _dbContext;
        public Repository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var obj = await _dbContext.Set<T>().FindAsync(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
                _dbContext.SaveChanges();
            }
        }

        public async Task<T> Get(int id)
        {
            var rs = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return rs;

        }

        public IQueryable<T> GetAll()
        {
            var rs = _dbContext.Set<T>().AsNoTracking();
            return rs;
        }

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression)
        {
            var rs = _dbContext.Set<T>().AsNoTracking().Where(expression);
            return rs;
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
