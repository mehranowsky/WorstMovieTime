using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace ModelLayer.Context
{
    public class WorstMoviesDbContext : DbContext
    {
        public WorstMoviesDbContext(DbContextOptions<WorstMoviesDbContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<FavoriteMovies> FavoriteMovies { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }
        public DbSet<MovieFiles> MovieFiles { get; set; }
        public DbSet<Countries> Countries { get; set; }        
    }
}
