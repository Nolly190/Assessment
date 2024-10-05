using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.Repositories.Interfaces
{
    public interface IGenericQueryRepository<T>
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetPaginatedAsync();
        Task<IQueryable<T>> GetPaginatedAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> RawQuery(string query, params SqlParameter[] parameters);
        Task<IQueryable<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>>? predicate, params string[] includes);
    }
}
