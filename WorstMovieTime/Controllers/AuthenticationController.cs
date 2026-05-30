using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Services;
using ServiceLayer.Utilities;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register([Bind("Name,PhoneNumber,Password")]RegisterViewModel registerInfo)
        {
            if (ModelState.IsValid)
            {
                OperationResult register = await _userService.Register(registerInfo);
                if (register.Status == OperationResult.ResultStatus.Success)
                    return Redirect("/Authentication/Verify");
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
        public async Task<IActionResult> Login([Bind("PhoneNumber,Password")]LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                OperationResult login = await _userService.Login(loginInfo);
                if(login.Status == OperationResult.ResultStatus.Success)
                    return RedirectToPage("/Home");
            }       
            return View(loginInfo);
        }
        [HttpGet]
        public IActionResult Verify(string phoneNumber)
        {
            var model = new VerifyViewModel
            {
                PhoneNumber = phoneNumber
            };
            return View();
        }
        [HttpPost]
        public IActionResult Verify(VerifyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Verify(model);
            }
                return View();
        }
    }
}
