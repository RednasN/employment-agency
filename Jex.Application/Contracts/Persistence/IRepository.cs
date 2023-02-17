using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
