using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace ApplicationLayer.Services
{
    public class Account : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Account(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        async Task<List<string>> IAccount.RegisterAsync(RegisterVM model)
        {
            var user = new ApplicationUser()
            {
                Name=model.Name,
                UserName=model.UserName,  
                Email=model.Email,
                CreatedDate=DateTime.Now,
                ModifiedDate = DateTime.Now,
               
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            List<String> errors = new List<String>();
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return errors;
                
            }
            await _signInManager.SignInAsync(user,false);
            return errors;

        }
        async Task<bool> IAccount.LoginAsync(LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false
                );
            return result.Succeeded;
        }

       

       async Task IAccount.LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
