using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using ServiceLayer.Services;

namespace WorstMovieTime.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Users> users = _userService.GetAll();
            return View(users);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _userService.GetEntity(id);
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetEntity(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(user);
            }
            return View(user);
        }
        public IActionResult Delete(Users user)
        {
            if (ModelState.IsValid)
            {
                _userService.Delete(user);
            }
            return View(user);
        }
    }
}
