using Day01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Day01.Data;

public class ITIDbContext : DbContext
{
    public ITIDbContext(DbContextOptions<ITIDbContext> options): base(options)
    {
        
    }

    public DbSet<Course> Courses { get; set; }
}
