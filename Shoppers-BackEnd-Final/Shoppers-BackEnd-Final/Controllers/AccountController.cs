using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_BackEnd_Final.Models;
using Shoppers_BackEnd_Final.Services;
using Shoppers_BackEnd_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager,DataContext context, SignInManager<AppUser> signInManager,IEmailService emailService)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> profileDetail()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Member = new MemberUpdateViewModel
                {
                    Email = user.Email,
                    FullName = user.Fullname,
                    UserName = user.UserName
                }
            };
            
            return View(profileVM);
        }


        [HttpPost]
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> profileDetail(MemberUpdateViewModel memberVM)
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Member = memberVM
               
            };

            if(!ModelState.IsValid)
            {
                return View(profileVM);
            }

            if(member.Email != memberVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == memberVM.Email))
            {
                ModelState.AddModelError("Email", "This email has alreadt been taken");
                return View(profileVM);
            }



            if (member.UserName != memberVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == memberVM.UserName))
            {
                ModelState.AddModelError("UserName", "This UserName has already been taken");
                return View(profileVM);
            }

            member.Email = memberVM.Email;
            member.Fullname = memberVM.FullName;
            member.UserName = memberVM.UserName;

            var result = await _userManager.UpdateAsync(member);

            if(!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(profileVM);
            }

            if (!string.IsNullOrWhiteSpace(memberVM.Password) && !string.IsNullOrWhiteSpace(memberVM.RepeatPassword))
            {
                if(memberVM.Password != memberVM.RepeatPassword)
                {
                    return View(profileVM);
                }

                if(!await _userManager.CheckPasswordAsync(member,memberVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "Current Password is not correct");
                    return View(profileVM);
                }

                var passwordResult = await _userManager.ChangePasswordAsync(member, memberVM.CurrentPassword, memberVM.Password);

                if(!passwordResult.Succeeded)
                {
                    foreach (var item in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }

                    return View(profileVM);
                }
            }

            _context.SaveChanges();

            await _signInManager.SignInAsync(member, true);

            return View(profileVM);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == loginVM.UserName.ToUpper() && x.IsAdmin == false);

            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect!");
                return View();
            }


            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberVM)
        {

            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(memberVM.UserName);
            if(user !=null)
            {
                ModelState.AddModelError("UserName", "Username already exist");
                return View();
            }

            if (_context.Users.Any(x=> x.NormalizedEmail == memberVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View();
            }

            user = new AppUser
            {
                Email = memberVM.Email,
                UserName = memberVM.UserName,
                Fullname = memberVM.FullName
            };

            var result = await _userManager.CreateAsync(user, memberVM.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("index","home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Forgot(ForgotPasswordViewModel forgotVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByEmailAsync(forgotVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "User not found");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("resetpassword", "account", new { email = user.Email, token = token }, Request.Scheme);
            _emailService.Send(user.Email, "Şifrə Dəyişikliyi", "<a href='" + url + "'>Şifrə Dəyişikliyi</a>");


            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null || !(await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetPasswordVM.Token)))
                return RedirectToAction("login");


            return View(resetPasswordVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordViewModel resetPasswordVM)
        {
            if (string.IsNullOrWhiteSpace(resetPasswordVM.Password) || resetPasswordVM.Password.Length > 25)
                ModelState.AddModelError("Password", "Password is required and must be less than 26 character");

            if (!ModelState.IsValid) return View("ResetPassword", resetPasswordVM);

            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null) return RedirectToAction("login");

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("ResetPassword", resetPasswordVM);
            }


            return RedirectToAction("thankyou");
        }

        public IActionResult thankyou()
        {
            return View();
        }
    }
}
