using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Services;
using ServiceLayer.Utilities;

namespace WorstMovieTime.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
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
        public IActionResult Register([Bind("Name,Email,Password,ConfirmPassword")]RegisterViewModel registerInfo)
        {
            if (ModelState.IsValid)
            {
                OperationResult register = _userService.Register(registerInfo);
                if (register.Status == OperationResult.ResultStatus.Success)
                    return Redirect("/");
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
        public IActionResult Login([Bind("Email,Password")]LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                OperationResult login = _userService.Login(loginInfo);
                if(login.Status == OperationResult.ResultStatus.Success)
                    return Redirect("/");
            }       
            return View(loginInfo);
        }        
    }
}
