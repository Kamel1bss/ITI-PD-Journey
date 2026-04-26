using Microsoft.AspNetCore.Identity;

namespace Day01.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int? Age { get; set; }
}
