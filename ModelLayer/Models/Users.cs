using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Models
{    
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Users : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(2, 25)]
        public string? Name { get; set; }
        [Required]
        [Length(11, 11)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }                
        [Required]
        [Length(8, 100)]
        public string? Password { get; set; }
        [Required]
        public bool IsVIP { get; set; } = false;
        public UserRole Role { get; set; } = UserRole.User;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        #region Relations
        public ICollection<Comments>? Comments { get; set; }
        public ICollection<FavoriteMovies>? FavoriteMovies { get; set; }
        #endregion

        public enum UserRole
        {
            Admin,
            User
        }
    }
}
