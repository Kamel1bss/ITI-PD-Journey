using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIEntities;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DeptId { get; set; }
    [Required]
    [StringLength(50)]
    public string DeptName { get; set; }

    public int Capacity {  get; set; }
    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

}
