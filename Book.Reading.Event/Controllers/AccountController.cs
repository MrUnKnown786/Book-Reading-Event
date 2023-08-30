using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Interfaces;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountPageService _accountPageService;
        public AccountController(IAccountPageService accountPageService)
        {
            this._accountPageService = accountPageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Sign-up")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("Sign-up")]
        public async Task<IActionResult> SignUp(SignUpViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountPageService.CreateUser(user);
                if (!result.Succeeded)
                {
                    foreach(var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountPageService.LoginUser(loginViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(loginViewModel);
                }
            }
            return View();
        }

        [Authorize]
        [Route("log-out")]
        public async Task<IActionResult> LogOut()
        {
            await _accountPageService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
