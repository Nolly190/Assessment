using Assessment.Infrastructure.Context;
using Assessment.Infrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.Repositories.Implementation
{
    public class GenericQueryRepository<T> : IGenericQueryRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        async Task<IQueryable<T>> IGenericQueryRepository<T>.RawQuery(string query, params SqlParameter[] parameters)
        {
            return _dbContext.Set<T>().FromSqlRaw(query, parameters).AsQueryable();
        }
        public async Task<IQueryable<T>> GetPaginatedAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }
        public async Task<IQueryable<T>> GetPaginatedAsync()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);
        }

        public async Task<IQueryable<T>> GetAllWithIncludeAsync(Expression<Func<T, bool>>? predicate, params string[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (predicate != null) 
            {
                query.Where(predicate);
            }
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
