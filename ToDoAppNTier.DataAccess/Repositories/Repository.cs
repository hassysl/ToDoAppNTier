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

        public async Task<T> GetById(object id)
        {
            return await _todoContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _todoContext.Set<T>().AsQueryable();
        }

        public void Remove(object id)
        {
            var deletedEntity = _todoContext.Set<T>().Find(id);
            _todoContext.Set<T>().Remove(deletedEntity);
        }

        public void Update(T entity)
        {
            var updatedEntity = _todoContext.Set<T>().Find(entity.Id);
            _todoContext.Entry(updatedEntity).CurrentValues.SetValues(entity);

            //_todoContext.Set<T>().Update(entity);
        }
    }
}
