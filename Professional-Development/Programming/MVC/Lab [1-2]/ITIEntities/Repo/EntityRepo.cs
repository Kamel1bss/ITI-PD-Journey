using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIEntities.Repo;

public class EntityRepo<T> : IEntityRepo<T> where T : class
{
    ITIContext _context;
    DbSet<T> _db;
    public EntityRepo(ITIContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }
    public void Add(T entity)
    {
        _db.Add(entity);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        _db.Remove(entity);
    }

    public IList<T> FindAll(Expression<Func<T, bool>> cond)
    {
        return _db.Where(cond).ToList();
    }

    public List<T> GetAll(string navprop = null)
    {
        if(navprop == null)
            return _db.ToList();
        return _db.Include(navprop).ToList();
    }

    public T GetById(int id)
    {
        return _db.Find(id);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _db.Update(entity);
    }
}
