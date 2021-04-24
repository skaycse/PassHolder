using Microsoft.EntityFrameworkCore;
using passholder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace passholder.Repo
{
    public interface ISqlRepository<T> where T : class
    {
        Task Insert(T param);
        Task Update(T param);
        Task Delete(Guid id);
        Task<T> GetSingle(Guid id);
        IQueryable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }

    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly PassDbContext _dbContext;

        public SqlRepository(PassDbContext passContext)
        {
            _dbContext = passContext;
        }

        public async virtual Task Delete(Guid id)
        {
            var entity = await GetSingle(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetSingle(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async virtual Task Insert(T param)
        {
            await _dbContext.Set<T>().AddAsync(param);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task Update(T param)
        {
            _dbContext.Set<T>().Update(param);
            await _dbContext.SaveChangesAsync();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(expression);
        }
    }
}
