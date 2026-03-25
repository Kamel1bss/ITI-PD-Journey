using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities;

public class Course
{
    public int CrsId { get; set; }
    // [NotMapped]
    public string CrsName { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } 


}
