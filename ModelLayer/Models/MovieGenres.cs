using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    [Index(nameof(GenreId), nameof(MovieId), IsUnique = true)]
    public class MovieGenres : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int MovieId { get; set; }

        #region Relations
        [ForeignKey(nameof(GenreId))]
        public Genres? Genre { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movies? Movie { get; set; }
        #endregion
    }
}
