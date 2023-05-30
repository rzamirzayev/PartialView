using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartialviewPage.Models;

namespace PartialviewPage.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminVM, string returnUrl = null)
        {
            AppUser appUser = await _userManager.FindByNameAsync(adminVM.UserName);

            if (appUser == null || !appUser.IsAdmin)
            {
                ModelState.AddModelError("", "Username or Password incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, adminVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }

            if (returnUrl != null)
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult ShowUser()
        {
            return Json(new
            {
                isAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
            });
        }
    }
}
