using Day01.Models;
using Day01.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Day01.Services;

public class DepartmentService(ITIDbContext context) : IDepartmentService
{
    private readonly ITIDbContext _context = context;

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken) =>
     await _context.Departments.Include(d=>d.Students).ToListAsync(cancellationToken);

    public async Task<Department?> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken) =>
            await _context.Departments.FindAsync(id, cancellationToken);

    public async Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken)
    {
        await _context.Departments.AddAsync(department, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return department;
    }

    public async Task<bool> DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
    {
        var department = await GetDepartmentByIdAsync(id, cancellationToken);
        if (department == null)
        {
            return false;
        }
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateDepartmentAsync(int id, Department Updateddepartment, CancellationToken cancellationToken)
    {
        var dept = await GetDepartmentByIdAsync(id, cancellationToken);
        if (dept == null)
        {
            return false;
        }
        dept.DeptName = Updateddepartment.DeptName;
        dept.DeptLocation = Updateddepartment.DeptLocation;
        dept.DeptDesc = Updateddepartment.DeptDesc;
        dept.DeptManager = Updateddepartment.DeptManager;
        dept.ManagerHiredate = Updateddepartment.ManagerHiredate;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


}
