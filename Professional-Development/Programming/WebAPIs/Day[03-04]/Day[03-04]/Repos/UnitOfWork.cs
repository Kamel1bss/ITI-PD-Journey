using Day01.Models;
using Day01.Persistence;

namespace Day01.Repos;

public class UnitOfWork: IUnitOfWork
{
    public IEntityRepo<Student> Students { get; private set; }
    public IEntityRepo<Department> Departments { get; private set; }

    private readonly ITIDbContext _context;

    public UnitOfWork(ITIDbContext context)
    {
        _context = context;
        Students = new EntityRepo<Student>(_context);
        Departments = new EntityRepo<Department>(_context);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {     
        return await _context.SaveChangesAsync(cancellationToken); 
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
