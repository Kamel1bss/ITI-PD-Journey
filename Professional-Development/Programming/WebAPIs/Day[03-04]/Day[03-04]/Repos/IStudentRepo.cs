using Day01.Contracts.Requests;
using Day01.Models;

namespace Day01.Repos;

public interface IStudentRepo
{
    public IUnitOfWork UnitOfWork { get; }

    // Additional method to get students with pagination and search
    Task<IEnumerable<Student>> GetAllStudentsAsync(StudentQueryRequest query, CancellationToken cancellationToken);

}
