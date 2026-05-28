using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Length(11, 11, ErrorMessage = "{0} صحیح نمباشد")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "{0} صحیح نمباشد")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(6)]
        public int OTPCode { get; set; }
    }
}
