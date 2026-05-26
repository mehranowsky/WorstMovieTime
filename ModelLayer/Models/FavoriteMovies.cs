using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    [Index(nameof(UserId), nameof(MovieId), IsUnique = true)]
    public class FavoriteMovies : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }

        #region Relations
        [ForeignKey(nameof(UserId))]
        public Users? User { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movies? Movie { get; set; }
        #endregion
    }
}
