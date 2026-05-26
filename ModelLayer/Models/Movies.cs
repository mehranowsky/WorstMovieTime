using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    [Index(nameof(Slug),IsUnique =true)]
    public class Movies : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Image { get; set; }
        [Required]
        [MaxLength(4)]
        public int ReleaseYear { get; set; }
        [Required]
        [MaxLength(60)]
        public string? Director { get; set; }
        [Required]        
        public int CountryProduct { get; set; }
        [Required]
        [MaxLength(2)]
        public string? IMDBscore { get; set; }
        [Required]
        public int Likes { get; set; }
        [Required]
        public string? Descreaption { get; set; }
        // Seo properties
        [Required]
        public string? Slug { get; set; }
        public string? MetaTag { get; set; }
        public string? MetaDescreaption { get; set; }

        #region Relations
        [ForeignKey(nameof(CountryProduct))]
        public Countries? Country { get; set; }
        public ICollection<ActorMovies>? Actors { get; set; }
        public ICollection<MovieGenres>? Genres { get; set; }
        public ICollection<Comments>? Comments { get; set; }
        #endregion
    }
}
