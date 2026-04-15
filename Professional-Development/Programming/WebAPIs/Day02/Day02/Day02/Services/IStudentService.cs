using Day01.Contracts.Requests;
using Day01.Models;

namespace Day01.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
    Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
    Task<Student> AddStudentAsync(Student student, CancellationToken cancellationToken);
    Task<bool> UpdateStudentAsync(int id, Student student, CancellationToken cancellationToken);
    Task<bool> DeleteStudentAsync(int id, CancellationToken cancellationToken);

    // Additional method to get students by department
    Task<IEnumerable<Student>> GetAllStudentsAsync(StudentQueryRequest query, CancellationToken cancellationToken);
}
