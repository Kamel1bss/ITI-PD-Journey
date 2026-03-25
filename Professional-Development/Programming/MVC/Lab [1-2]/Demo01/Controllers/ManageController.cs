using ITIEntities.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo01.Controllers
{
    [Authorize(Roles = SD.Roles.Admin)]
    public class ManageController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<IdentityUser> _signManager;
        public ManageController(UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<IdentityUser> signInManager)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
        }
        public IActionResult GetAllUsers()
        {
            var model = _userManager.Users.ToList();
            return View(model);
        }

        public async Task<IActionResult> UpdateRoles(string id)
        {
            var allRoles = _roleManager.Roles.Select(r=>r.Name).ToList();
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var noAssignedRoles = allRoles.Except(userRoles);

            ViewBag.userRoles = userRoles;
            ViewBag.noAssignedRoles = noAssignedRoles;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoles(string id, List<string> RolesToRemove, List<string> RolesToAdd)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
            {
                await _userManager.RemoveFromRolesAsync(user, RolesToRemove);
                await _userManager.AddToRolesAsync(user, RolesToAdd);
            }
            return RedirectToAction(nameof(UpdateRoles), new {id = id});
        }
    }
}
