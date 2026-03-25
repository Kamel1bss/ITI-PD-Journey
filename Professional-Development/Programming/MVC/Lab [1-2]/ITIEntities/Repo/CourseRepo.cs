using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIEntities.Repo;

public class CourseRepo : IEntityRepo<Course>
{
    ITIContext _context;
    public CourseRepo(ITIContext context)
    {
        _context = context;
    }

    public IList<Course> FindAll(Expression<Func<Course, bool>> cond)
    {
        return _context.Courses.Where(cond).ToList();
    }
    public List<Course> GetAll()
    {
        // Eager loading => Include
        return _context.Courses
            .Include(c => c.Departments)
            .Include(c => c.StudentCourses)
            .ToList();
    }

    public Course GetById(int id)
    {
        return _context.Courses
            .Include(c => c.Departments)
            .Include(c => c.StudentCourses)
            .FirstOrDefault(c => c.CrsId == id);
    }

    public void Add(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public void Update(Course course)
    {
        _context.Courses.Update(course);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var course = GetById(id);
        _context.Courses.Remove(course);
        _context.SaveChanges();
    }

    public List<Course> GetAll(string navprop = null)
    {
        throw new NotImplementedException();
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }
}
