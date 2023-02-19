using Jex.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Infrastructure.Persistence
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly JexDbcontext _jexDbContext;
        public BaseRepository(JexDbcontext jexDbContext)
        {
            _jexDbContext = jexDbContext;
        }

        public async Task Add(T entity)
        {
            _jexDbContext.Add(entity);
            await _jexDbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _jexDbContext.Remove(entity);
            await _jexDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _jexDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            return await query.ToListAsync();
        }

        public async Task Update(T entity)
        {
            _jexDbContext.Update(entity);
            await _jexDbContext.SaveChangesAsync();
        }
    }
}
