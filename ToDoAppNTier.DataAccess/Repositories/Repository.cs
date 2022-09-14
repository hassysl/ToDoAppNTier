using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ToDoContext _todoContext;

        public Repository(ToDoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task Create(T entity)
        {
            await _todoContext.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _todoContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _todoContext.Set<T>().SingleOrDefaultAsync(filter) : await _todoContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _todoContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _todoContext.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _todoContext.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _todoContext.Entry(unchanged).CurrentValues.SetValues(entity);

            //_todoContext.Set<T>().Update(entity);
        }
    }
}
