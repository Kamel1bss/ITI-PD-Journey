using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIEntities;

public class Student
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    public int Age { get; set; }

    public string Email { get; set; }

    [ForeignKey(nameof(Department))]
    public int DeptNum { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }

}
