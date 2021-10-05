using BLL.Interfaces;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginAsync(LoginViewModel loginVM)
        {
            var result = await _signInManager.PasswordSignInAsync(loginVM.Login, loginVM.Password, loginVM.RememberMe, false);

            return result;
        }

        public async Task<User> RegisterAsync(RegisterViewModel register)
        {
            var applicationUser = new User();
            if (register.Password == register.RepeatPassword)
            {
                applicationUser = new User
                {
                    UserName = register.Login,
                    NormalizedUserName = register.Login.Normalize().ToUpperInvariant(),
                    Email = register.Email,
                    NormalizedEmail = register.Email.Normalize().ToUpperInvariant(),
                    EmailConfirmed = false

                };

                var resultRegistration = await _userManager.CreateAsync(applicationUser, register.Password);

                if (!resultRegistration.Succeeded)
                {
                    var errorsRegistration = "";
                    foreach (var error in resultRegistration.Errors)
                    {
                        errorsRegistration += error.Code + ";";
                    }
                }
            }
            return applicationUser;
        }
    }
}
