using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ01;

internal static class Data
{
    public static List<Course> Courses = new List<Course>
    {
        new Course { Id = 1, Name = "C#", Hours = 40 },
        new Course { Id = 2, Name = "Java", Hours = 35 },
        new Course { Id = 3, Name = "Python", Hours = 30 },
        new Course { Id = 4, Name = "JavaScript", Hours = 25 },
        new Course { Id = 5, Name = "SQL", Hours = 20 },
        new Course { Id = 6, Name = "HTML", Hours = 15 },
        new Course { Id = 7, Name = "CSS", Hours = 10 },
        new Course { Id = 8, Name = "React", Hours = 45 },
        new Course { Id = 9, Name = "Angular", Hours = 50 },
        new Course { Id = 10, Name = "Vue", Hours = 55 }
    };
}
