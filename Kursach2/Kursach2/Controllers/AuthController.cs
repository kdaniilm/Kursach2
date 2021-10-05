using BLL.Interfaces;
using BLL.Servises;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public AuthController(IAuthService authService, UserManager<User> userManager, IEmailSender emailSender)
        {
            _authService = authService;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        #region Registration
        [HttpGet]
        public async Task<IActionResult> Register() => await Task.Run(() => View());

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var user = await _authService.RegisterAsync(register);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmailResponce", "Auth",
                new { userToken = token, userId = user.Id }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(user.Email, "Click on this link to verificated email: ", link);

            return View("ConfirmEmailRequest", user.Email);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmailResponce(string userToken, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var confirmationResult = await _userManager.ConfirmEmailAsync(user, userToken);
            if (confirmationResult.Succeeded)
            {
                return await Task.Run(() => View());
            }
            else
            {
                return await Task.Run(() => new StatusCodeResult(500));
            }
        }
        #endregion

        #region Login
        [HttpGet]
        public async Task<IActionResult> Login() => await Task.Run(() => View());

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            var result = await _authService.LoginAsync(loginVM);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return new StatusCodeResult(403);
            }
        }
        #endregion
    }
}
