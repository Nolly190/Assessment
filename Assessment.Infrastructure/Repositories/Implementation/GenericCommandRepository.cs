using Assessment.Infrastructure.Context;
using Assessment.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Infrastructure.Repositories.Implementation
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T> where T : class
    {
        public ApplicationDbContext _dbContext { get; set; }
        public GenericCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> InsertAsync(T entity)
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> InsertAndRetrieveIdAsync(T entity)
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            var record = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> InsertRangeAsync(List<T> entities)
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbContext.Set<T>().AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
