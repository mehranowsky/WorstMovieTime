namespace ModelLayer.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Movies> NewMovies { get; set; }
        public IEnumerable<Movies> PopularMovies { get; set; }
        public IEnumerable<Movies> LeastScores { get; set; }
    }
}
