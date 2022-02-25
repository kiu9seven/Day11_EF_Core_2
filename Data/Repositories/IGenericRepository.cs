using Day11.Data.Entities;

namespace Day11.Data.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T? Get(long id);
    Task<T?> GetAsync(long id);
    T Insert(T entity);
    Task<T> InsertAsync(T entity);
    T Update(T entity);
    Task<T> UpdateAsync(T entity);
    void Delete(T entity);
    Task DeleteAsync(T entity);
}