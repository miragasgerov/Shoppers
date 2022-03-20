using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser
            {
                UserName = "MiragaAdmin",
                Fullname = "Super Admin"
            };

            var result = await _userManager.CreateAsync(appUser, "Miraga123");

            return Ok(result);
        }
    }
}
