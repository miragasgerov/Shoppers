using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shoppers_BackEnd_Final.Areas.manage.ViewModels;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            //AppUser user = _userManager.FindByNameAsync("SuperAdmin").Result;
            //var result = _userManager.AddToRoleAsync(user, "SuperAdmin").Result;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = _userManager.Users.FirstOrDefault(x => x.UserName==loginVM.UserName);

            if (admin == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect!");
                return View();
            }

          

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect!");
                return View();
            }


            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok();
        }
    }
}
