using FireAuth.Domain.Contracts.Interfaces;

namespace FireAuth.Shared.Services;

public class CrudService<T>(ICrudRepository<T> repository) : ICrudService<T> where T : class
{

    public async Task<IEnumerable<T>> GetAllAsync()
    {
         return await repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        await repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        await repository.Delete(entity);
    }


}
