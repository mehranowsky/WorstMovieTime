using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    [Index(nameof(Slug), IsUnique = true)]
    public class Actors : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(70)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(70)]
        public string? Image { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Slug { get; set; }

        #region Relations
        public ICollection<ActorMovies>? Movies { get; set; }
        #endregion
    }
}
