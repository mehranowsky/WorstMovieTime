using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class MovieService : GenericService<Movies>, IMovieService
    {
        private readonly WorstMoviesDbContext _context;
        public MovieService(WorstMoviesDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movies> ActorMovies(int actorId)
        {
            var moviesId = _context.ActorMovies
                .Where(e => e.ActorId == actorId)
                .Select(e => e.MovieId);
            IEnumerable<Movies> movies = _context.Movies.Where(m => moviesId.Contains(m.Id));
            return movies;
        }

        public IEnumerable<Movies> CountryBased(int countryId)
        {
            IEnumerable<Movies> movies = _context.Movies.Where(m => m.CountryProduct == countryId);
            return movies;
        }

        public IEnumerable<Movies> GenreBased(int genreId)
        {
            var moviesId = _context.MovieGenres
                .Where(e=>e.GenreId == genreId)
                .Select(g=>g.MovieId);
            IEnumerable<Movies> movies = _context.Movies.Where(m => moviesId.Contains(m.Id));
            return movies;
        }

        public IEnumerable<Movies> LeastScore()
        {
            IEnumerable<Movies> leastScoreMovies = _context.Movies.OrderBy(e => e.IMDBscore);
            return leastScoreMovies;
        }

        public IEnumerable<Movies> NewMovies()
        {
            IEnumerable<Movies> newMovies = _context.Movies.OrderByDescending(e=>e.ReleaseYear);
            return newMovies;
        }

        IEnumerable<Movies> IMovieService.PopularMovies()
        {
            IEnumerable<Movies> popularMovies = _context.Movies.OrderByDescending(e => e.Likes);
            return popularMovies;
        }
    }
}
