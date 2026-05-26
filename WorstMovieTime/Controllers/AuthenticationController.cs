using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Services;

namespace WorstMovieTime.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Name,PhoneNumber,Password")]RegisterViewModel registerInfo)
        {
            if (ModelState.IsValid)
            {
                bool registerSuccess = _userService.Register(registerInfo);
                if (registerSuccess)
                {
                    return RedirectToPage("/");
                }
            }
            return View(registerInfo);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]        
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("PhoneNumber,Password")]LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                bool loginSuccess = _userService.Login(loginInfo);
                return RedirectToPage("/");
            }
            return View(loginInfo);
        }
    }
}
