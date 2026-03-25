using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF01;

public class Employee
{
    public int Id{set; get;}
    [Column("FullName")]
    [Required, MaxLength(100)]
    public string Name{ get; set; } = string.Empty;
    public double? Salary{ get; set; }
    [Required]
    public string Address { get; set; }
    [Column(TypeName = "Date")]
    public DateTime BirthDate { get; set; }

    //[ForeignKey("Dept")]
    public int SupervisedDeptId { get; set; }
    [ForeignKey("SupervisedDeptId")]
    public virtual Department SupervisedDept { get; set; }
    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public virtual Department Dept { get; set; } // virtual => lazy loading
    public virtual ICollection<WorksFor> WorksFors { get; set; } // lazy loading
    //public virtual ICollection<Project> Projects { get; set; } // lazy loading

}
