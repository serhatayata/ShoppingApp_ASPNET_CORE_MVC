﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entity.ViewModels;
using ShoppingApp.Repository.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                var roles = await userManager.GetRolesAsync(user);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user,model.Password,false,false);
                    if (result.Succeeded && roles[0]=="user")
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                    else if (result.Succeeded && roles[0]=="admin")
                    {
                        return Redirect(returnUrl ?? "/Admin/CatalogList");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Hatalı E-mail veya Parola");
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser user, string password)
        {
            if (await userManager.FindByNameAsync(user.UserName) == null)
            {
                string role = "user";

                ApplicationUser _user = new ApplicationUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
            return RedirectToAction("Login","Account");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View("Errors/Error1");
        }
    }
}
