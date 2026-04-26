using Day01.Models;

namespace Day01.Repos;

public interface IUnitOfWork : IDisposable
{
    public IEntityRepo<Student> Students { get;}
    public IEntityRepo<Department> Departments { get;}

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
  
}
