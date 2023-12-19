namespace pmesp.Domain.Interfaces.Base;

public interface IRepository<T>
{
    Task<ICollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
