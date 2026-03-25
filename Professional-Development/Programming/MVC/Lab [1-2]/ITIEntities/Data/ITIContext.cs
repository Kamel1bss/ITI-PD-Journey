using ITIEntities.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities.Data
{
    public class ITIContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITIAlex46;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
            (
                 new IdentityRole
                 {
                     Name = SD.Roles.Student
                 },
                new IdentityRole
                {
                    Name = SD.Roles.Admin

                },
                new IdentityRole
                {
                    Name = SD.Roles.Instructor

                }
            );
            modelBuilder.Entity<StudentCourse>(s => {

                s.HasKey(s => new { s.StudentId, s.CrsId });
            });

            modelBuilder.Entity<Course>(s => {
                s.HasKey(s => s.CrsId);
                s.Property(s => s.CrsId)
                .ValueGeneratedNever();
                s.Property(s => s.CrsName)
                .IsRequired()
                .HasMaxLength(50);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
