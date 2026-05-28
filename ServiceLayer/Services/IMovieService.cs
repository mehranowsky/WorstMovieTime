using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public interface IMovieService : IGenericService<Movies>
    {
        IEnumerable<Movies> NewMovies();
        IEnumerable<Movies> PopularMovies();
        IEnumerable<Movies> LeastScores();
        IEnumerable<Movies> GenreBased(int genreId);
        IEnumerable<Movies> CountryBased(int countryId);
        IEnumerable<Movies> ActorMovies(int actorId);
    }
}
