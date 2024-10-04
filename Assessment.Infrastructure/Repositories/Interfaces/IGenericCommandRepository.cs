namespace Assessment.Infrastructure.Repositories.Interfaces
{
    public interface IGenericCommandRepository<T>
    {
        Task<T> InsertAndRetrieveIdAsync(T entity);
        Task<int> InsertAsync(T entity);
        Task<int> InsertRangeAsync(List<T> entities);
        Task<int> UpdateAsync(T entity);
    }
}
