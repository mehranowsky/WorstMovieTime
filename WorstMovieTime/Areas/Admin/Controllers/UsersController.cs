using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Services;

namespace WorstMovieTime.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Users> users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users newUser)
        {
            if (ModelState.IsValid)
            {               
                _userService.Add(newUser);
                _userService.Save();
                return RedirectToAction("Index");
            }
            return View(newUser);
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
                user.UpdatedAt = DateTime.Now;
                _userService.Update(user);
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetEntity(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
