using System.ComponentModel.DataAnnotations;

namespace Demo01.Models.ViewModels;

public class LoginVM
{
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
