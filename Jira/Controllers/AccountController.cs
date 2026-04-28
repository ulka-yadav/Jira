using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModel;

namespace Jira.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _user;

        public AccountController(IAccount user)
        {
            _user = user;
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var errors = await _user.RegisterAsync(model);
            if (errors.Count == 0)
            {
                return RedirectToAction( "Login");
            }
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error); //display validation error
            }
            return View(model);
           
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _user.LoginAsync(model);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("","Invalid Login Attempt");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _user.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }
       

    }
}
