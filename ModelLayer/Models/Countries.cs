using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class Countries : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        #region Relations
        public ICollection<Movies>? Movies { get; set; }
        #endregion
    }
}
