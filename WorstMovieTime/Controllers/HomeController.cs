using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models.ViewModels;
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
            var homePageViewModel = new HomePageViewModel
            {
                NewMovies = _movieService.NewMovies(),
                PopularMovies = _movieService.PopularMovies(),
                LeastScores = _movieService.LeastScores()
            };
            return View(homePageViewModel);
        }
        
    }
}
