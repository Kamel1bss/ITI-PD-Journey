using ITIEntities;
using System.ComponentModel.DataAnnotations;

namespace Demo01.Models.ViewModels;

public class CourseVM
{
    [Required(ErrorMessage = "Course ID is required")]
    public int CrsId { get; set; }
    [Required(ErrorMessage = "Course Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Course Name must be between 3 and 100 characters")]
    public string CrsName { get; set; }
    [Required(ErrorMessage = "Course Duration is required")]
    [Range(1, 52, ErrorMessage = "Course Duration must be between 1 and 52 weeks")]
    public int Duration { get; set; }

    // adding list of departments for dropdown
   
    [Required(ErrorMessage = "Department is required")]
    [Display(Name = "Department")]
    //[Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
    public List<int> DepartmentIds { get; set; } = new List<int>();
}
