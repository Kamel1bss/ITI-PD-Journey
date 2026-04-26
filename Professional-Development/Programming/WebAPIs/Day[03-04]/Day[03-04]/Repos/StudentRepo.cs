using Day01.Contracts.Requests;
using Day01.Models;
using Microsoft.EntityFrameworkCore;

namespace Day01.Repos;

public class StudentRepo : IStudentRepo
{

    public IUnitOfWork UnitOfWork { get; }

    public StudentRepo(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    // pagination + searching
    public async Task<IEnumerable<Student>> GetAllStudentsAsync(
        StudentQueryRequest query,
        CancellationToken cancellationToken)
    {
        var result = UnitOfWork.Students.Query();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            result = result.Where(s =>
                s.StFname.Contains(query.Search) ||
                s.StLname.Contains(query.Search));
        }

        return await result
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
    }
}