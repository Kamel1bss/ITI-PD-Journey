using Day01.Models;

namespace Day01.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken);
    Task<Department?> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken);
    Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken);
    Task<bool> UpdateDepartmentAsync(int id, Department department, CancellationToken cancellationToken);
    Task<bool> DeleteDepartmentAsync(int id, CancellationToken cancellationToken);
}
