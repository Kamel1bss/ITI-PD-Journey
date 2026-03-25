using Microsoft.EntityFrameworkCore;

namespace EF01;
internal class Program
{
    static void Main(string[] args)
    {
        AppDbContextFactory _factory = new AppDbContextFactory();
        var _context = _factory.CreateDbContext(args);
        _context.Employees.Add
            (new Employee { Name = "kamel", Salary = 12000 });

        _context.SaveChanges();

    }
}
