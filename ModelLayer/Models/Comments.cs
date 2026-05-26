using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class Comments : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Text { get; set; }
        [Required]
        public int Likes { get; set; } = 0;
        [Required]
        public int Dislikes { get; set; } = 0;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        #region
        [ForeignKey(nameof(UserId))]
        public Users? User { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movies? Movie { get; set; }
        #endregion
    }
}
