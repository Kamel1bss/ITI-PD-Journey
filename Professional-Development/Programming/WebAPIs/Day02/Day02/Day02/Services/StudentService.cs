using Day01.Contracts.Requests;
using Day01.Models;
using Day01.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Day01.Services;

public class StudentService(ITIDbContext context) : IStudentService
{
    private readonly ITIDbContext _context = context;

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken cancellationToken) =>
         await _context.Students.Include(s=>s.Dept).ToListAsync(cancellationToken);

    public async Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken) =>
         await _context.Students.FindAsync(id, cancellationToken);
    public async Task<Student> AddStudentAsync(Student student, CancellationToken cancellationToken)
    {
        await _context.Students.AddAsync(student, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return student;

    }

    public async Task<bool> DeleteStudentAsync(int id, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(id, cancellationToken);
        if (student == null)
        {
            return false;
        }
        _context.Students.Remove(student);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<bool> UpdateStudentAsync(int id, Student Updatedstudent, CancellationToken cancellationToken)
    {
        var stud = await GetStudentByIdAsync(id, cancellationToken);
        if (stud == null)
        {
            return false;
        }
        
        stud.StId = Updatedstudent.StId;
        stud.StFname = Updatedstudent.StFname;
        stud.StLname = Updatedstudent.StLname;
        stud.StAddress = Updatedstudent.StAddress;
        stud.StAge = Updatedstudent.StAge;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    // pagination and searching
    public async Task<IEnumerable<Student>> GetAllStudentsAsync(
    StudentQueryRequest query,
    CancellationToken cancellationToken)
    {
        var result = _context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            result = result.Where(s =>
                s.StFname.Contains(query.Search) || s.StLname.Contains(query.Search));
        }

        result = result
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize);

        return await result.ToListAsync(cancellationToken);
    }
}
