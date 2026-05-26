using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class Genres : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

    }
}
