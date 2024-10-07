using System;
using FireAuth.Domain.Contracts.Interfaces;
using FireAuth.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FireAuth.Infrastructure.Repositories;

public class CrudRepository<T>(FireAuthDbContext context) : ICrudRepository<T> where T : class
{
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync(); 
    }

    public async Task Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync(); // Save changes to persist the deletion
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

   public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity)
    {
         context.Set<T>().Update(entity);
         await context.SaveChangesAsync();
    }
}
