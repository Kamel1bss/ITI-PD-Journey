using Microsoft.EntityFrameworkCore;

namespace EF01;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<Project> Projects { get; set; }
}
