using System.ComponentModel.DataAnnotations;
using static ModelLayer.Models.Users;

namespace ModelLayer.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Length(2, 25)]
        public string? Name { get; set; }
        [Length(11, 11)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(70)]
        public string? Email { get; set; }
        [Required]
        public bool EmailConfirmation { get; set; }
        [Required]
        [Length(8, 100)]
        public string? Password { get; set; }
        [Required]
        public bool IsVIP { get; set; }
        [Required]
        public UserRole Role { get; set; }        
    }
}
