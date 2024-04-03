using Microsoft.EntityFrameworkCore;
using TrainingWebsite.Application.Contracts.Persistence;
using TrainingWebsite.Persistence.DatabaseContext;

namespace TrainingWebsite.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var entities = await _context.Set<T>().AsNoTracking().ToListAsync();
        return entities;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        //⚠️ We can improve this by using AsNoTracking() to improve performance, if the app will not update the entities
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(Guid id)
    {
        return await _context.Set<T>().FindAsync(id) != null;
    }
}