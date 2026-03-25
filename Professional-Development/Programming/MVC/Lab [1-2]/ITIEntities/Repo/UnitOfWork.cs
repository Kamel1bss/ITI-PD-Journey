using ITIEntities.Data;

namespace ITIEntities.Repo;

public interface IUnitOfWork
{
    public EntityRepo<Department> _deptRepo { get; }
    public EntityRepo<Student> _studRepo { get; }

    public EntityRepo<Course> _courseRepo { get; }

    int SaveContext();
}
public class UnitOfWork : IUnitOfWork
{
    ITIContext _context;

    public EntityRepo<Department> _deptRepo { get; }
    public EntityRepo<Student> _studRepo { get; }
    public EntityRepo<Course> _courseRepo { get; }

    public UnitOfWork(ITIContext context)
    {
        _context = context;
        _deptRepo = new EntityRepo<Department>(_context);
        _studRepo = new EntityRepo<Student>(_context);
        _courseRepo = new EntityRepo<Course>(_context);
    }

    public int SaveContext()
    {
        return _context.SaveChanges();
    }
}
