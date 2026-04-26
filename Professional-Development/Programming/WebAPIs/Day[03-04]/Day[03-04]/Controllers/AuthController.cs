using Day01.Contracts.Requests;
using Day01.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day01.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    [HttpPost("Register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        var result = _userManager.CreateAsync(user, request.Password).Result;
        _userManager.AddToRoleAsync(user, "User").Wait();


        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return Ok();
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // get by email
        var user = _userManager.FindByEmailAsync(request.Email).Result;
        if (user == null)
        {
            return Unauthorized();
        }

        // match password
        var isPasswordValid = _userManager.CheckPasswordAsync(user, request.Password).Result;
        if (!isPasswordValid)
        {
            return Unauthorized();
        }

        List<string> roles = _userManager.GetRolesAsync(user).Result.ToList();

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, request.Email),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AhmedKamelFaroukAyadITIALEXPDTRACK_CRM")),
                SecurityAlgorithms.HmacSha256)
        );
        return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}

