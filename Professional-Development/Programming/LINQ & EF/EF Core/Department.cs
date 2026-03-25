using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01;

[Table("Depts", Schema ="HR")]
public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    [InverseProperty("Dept")]
    public virtual ICollection<Employee> Employees {get; set;} // lazy loading
    [InverseProperty("SupervisedDept")]
    public virtual ICollection<Employee> Supervisors {get; set;} // lazy loading
    public virtual ICollection<Project> Projects {get; set;} // lazy loading
}
