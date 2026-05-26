using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using ServiceLayer.Services;

namespace WorstMovieTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            IEnumerable<Movies> newMovies = _movieService.NewMovies();
            IEnumerable<Movies> popularMovies = _movieService.PopularMovies();
            return View();
        }
        
    }
}
