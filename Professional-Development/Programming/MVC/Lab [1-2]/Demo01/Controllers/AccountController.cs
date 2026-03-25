using Demo01.Models.ViewModels;
using ITIEntities;
using ITIEntities.Repo;
using ITIEntities.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Security.Claims;

namespace Demo01.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<IdentityUser> _signManager;
        public AccountController(UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<IdentityUser> signInManager)
                                
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, SD.Roles.Admin);
                await _signManager.SignInAsync(user, isPersistent:false);
                return RedirectToAction("index", "home");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", $"{item.Code} {item.Description}");
                return View(model);
            }

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
           var result = await _signManager.PasswordSignInAsync(model.UserName,
                                                               model.Password,
                                                               isPersistent:false,
                                                               lockoutOnFailure:true);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return View(model);
            }
                
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
