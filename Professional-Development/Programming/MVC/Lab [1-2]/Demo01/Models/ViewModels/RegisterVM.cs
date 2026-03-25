using System.ComponentModel.DataAnnotations;

namespace Demo01.Models.ViewModels;
public class RegisterVM
{
    [Required, StringLength(100, MinimumLength = 5)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [Display(Name = "Password")]
    
    public string Password { get; set; }
    [Required] 
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

}
