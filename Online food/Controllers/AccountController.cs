using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Online_food.Data.Repositories;
using Online_food.Models;

namespace Online_food.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userRepository.IsExistUserByPhone(register.Phone))
            {
                ModelState.AddModelError("Phone","این شماره تلفن قبلا ثبت شده است.");
                return View(register);
            }

            Users user = new Users()
            {
                FullName = register.FullName,
                Phone = register.Phone,
                Password = register.Password.ToLower(),
                Address = register.Address,
                Plaque = register.Plaque,
                Postalcode = register.Postalcode,
                RegisterDate = DateTime.Now,
                IsAdmin = false
            };

            _userRepository.AddUser(user);
            return Redirect("/Login");
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userRepository.GetUsersForLogin(login.Phone, login.Password.ToLower());
            if (user == null)
            {
                ModelState.AddModelError("Phone","اطلاعات صحیح نیست.");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("IsAdmin", user.IsAdmin.ToString())

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
