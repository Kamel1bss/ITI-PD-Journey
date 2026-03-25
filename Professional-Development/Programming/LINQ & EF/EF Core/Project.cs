using System.ComponentModel.DataAnnotations;
namespace EF01;

public class Project
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public virtual Department Department { get; set; }
    public virtual ICollection<WorksFor> WorksFors { get; set; } // lazy loading

    //public virtual ICollection<Employee> Employees { get; set; } // lazy loading

}
