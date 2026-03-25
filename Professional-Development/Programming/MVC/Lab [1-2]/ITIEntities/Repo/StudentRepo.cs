using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIEntities.Repo;

public class StudentRepo : IEntityRepo<Student>
{
    ITIContext _context;
    public StudentRepo(ITIContext context)
    {
        _context = context;
    }

    public IList<Student> FindAll(Expression<Func<Student, bool>> cond)
    {
        return _context.Students.Where(cond).ToList();
    }
    public List<Student> GetAll()
    {
        // Eager loading => Include
        return _context.Students.Include(s => s.Department).ToList();
    }

    public Student GetById(int id)
    {
        return _context.Students.Include(s=>s.Department).FirstOrDefault(s=>s.Id == id);
    }

    public void Add(Student student)
    {
        _context.Students.Add(student);
    }

    public void Update(Student student)
    {
        _context.Students.Update(student);
    }

    public void Delete(int id)
    {
        var student = GetById(id);
        _context.Students.Remove(student);
    }

    public List<Student> GetAll(string navprop = null)
    {
        if (navprop != null) {
            return _context.Students.Include(navprop).ToList();
        }
        else
        {
            return _context.Students.ToList();
        }
    }
}
