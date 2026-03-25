using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Demo01.Models.ViewModels;

public class StudentVM
{
    public int Id { get; set; }
    [Required, StringLength(50, MinimumLength=3)]
    public string Name { get; set; }

    [Required, StringLength(50, MinimumLength = 3)]
    [Remote("CheckEmail", "Student", AdditionalFields = nameof(Id))]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    public int Age { get; set; }
    public int DeptNum { get; set; }
}
