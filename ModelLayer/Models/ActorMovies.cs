using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    [Index(nameof(ActorId), nameof(MovieId), IsUnique =true)]
    public class ActorMovies : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }

        #region Relations
        [ForeignKey(nameof(ActorId))]
        public Actors? Actor { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movies? Movie { get; set; }
        #endregion
    }
}
