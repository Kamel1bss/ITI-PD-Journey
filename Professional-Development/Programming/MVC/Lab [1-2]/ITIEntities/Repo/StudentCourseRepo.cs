using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIEntities.Repo;
public class StudentCourseRepo
{
    ITIContext _context;
    public StudentCourseRepo(ITIContext context)
    {
        _context = context;
    }
    public void Add(StudentCourse entity)
    {
        _context.StudentCourses.Add(entity);
        _context.SaveChanges();
    }


    public void AddRange(List<StudentCourse> entities)
    {
        _context.StudentCourses.AddRange(entities);
        _context.SaveChanges();
    }

    public IList<StudentCourse> FindAll(Expression<Func<StudentCourse, bool>> cond)
    {
         return _context.StudentCourses
            .Include(sc=>sc.Student)
            .Include(sc=>sc.Course)
            .Where(cond).ToList();
    }

    public List<StudentCourse> GetAll()
    {
        return _context.StudentCourses
            .Include(sc => sc.Student)
            .Include(sc => sc.Course)
            .ToList();
    }

    public StudentCourse GetByIds(int studentId, int crsId)
    {
        return _context.StudentCourses
            .Include(sc => sc.Student)
            .Include(sc => sc.Course)
            .FirstOrDefault(sc => sc.CrsId == crsId && sc.StudentId == studentId);
    }

    public void Update(StudentCourse entity)
    {
        _context.StudentCourses.Update(entity);
        _context.SaveChanges();
    }

    public void UpdateRange(List<StudentCourse> entities)
    {
        _context.StudentCourses.UpdateRange(entities);
        _context.SaveChanges();
    }
}
