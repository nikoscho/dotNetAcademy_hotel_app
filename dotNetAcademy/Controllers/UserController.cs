using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.Models;
using dotNetAcademy.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAcademy.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public UserController(SignInManager<User> signInManager) {
            this._signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {

                var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;

                if (result.Succeeded) {
                    return RedirectToAction("Profile", "Home");
                } else {
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Invalid login attempt");

            return View(model);
        }

        [HttpGet]
        public IActionResult Logout() {

            if (ModelState.IsValid) {
                var result = _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }

}