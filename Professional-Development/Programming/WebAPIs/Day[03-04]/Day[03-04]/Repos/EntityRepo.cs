using Day01.Models;
using Day01.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Day01.Repos;

public class EntityRepo<T> : IEntityRepo<T> where T : class
{
    private readonly ITIDbContext _context;
    private readonly DbSet<T> _entities;

    public EntityRepo(ITIDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) =>
    await _entities.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
    await _entities.FindAsync(new object[] { id }, cancellationToken);

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _entities.AddAsync(entity, cancellationToken);
        // save changes to get the generated ID (if any)

        return entity;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {

        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            return false;
        }
        _entities.Remove(entity);
        return true;
    }


    public async Task<bool> UpdateAsync(int id, T entity, CancellationToken cancellationToken)
    {
        var existingEntity = await GetByIdAsync(id, cancellationToken);
        if (existingEntity == null)
            return false;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return true;
    }

    public IQueryable<T> Query() => _entities.AsQueryable();

}
