using System;

namespace FireAuth.Domain.Contracts.Interfaces;

public interface ICrudRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task Delete(T entity);

}
