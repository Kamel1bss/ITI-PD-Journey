using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIEntities.Repo;
public class DepartmentRepo : IEntityRepo<Department>
{
    ITIContext _context;
    public DepartmentRepo(ITIContext context)
    {
        _context = context;
    }

    public void Add(Department department)
    {
        _context.Departments.Add(department);
    }

    public void Delete(int id)
    {
        var department = GetById(id);
        _context.Departments.Remove(department);
    }

    public IList<Department> FindAll(Expression<Func<Department, bool>> cond)
    {
       return _context.Departments.Where(cond).ToList();
    }

    public List<Department> GetAll()
    {
        return _context.Departments.Include(s => s.Students).ToList();
    }

    public List<Department> GetAll(string navprop = null)
    {
        return _context.Departments.Include(s => s.Students).ToList();
    }

    public Department GetById(int id)
    {
        return _context.Departments
            .Include(d => d.Students)
            .Include(d => d.Courses)
            .SingleOrDefault(d=>d.DeptId == id);
    }


    public void Update(Department department)
    {
        _context.Departments.Update(department);
    }
}
