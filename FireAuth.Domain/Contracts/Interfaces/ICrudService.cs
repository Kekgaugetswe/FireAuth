
namespace FireAuth.Domain.Contracts.Interfaces;

public interface ICrudService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task Delete(int id);

}
