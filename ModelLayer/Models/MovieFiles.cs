using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class MovieFiles : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        public int Episode { get; set; }
        [Required]
        [MaxLength(150)]
        public string? DownloadLink { get; set; }
        [Required]
        public ContentQuality Quality { get; set; }

        #region Relations
        [ForeignKey(nameof(MovieId))]
        public Movies? Movie { get; set; }
        #endregion

        public enum ContentQuality
        {
            p480 = 480,
            p720 = 720,
            p1080 = 1080
        }
    }
}
