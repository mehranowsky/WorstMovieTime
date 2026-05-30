using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "بیش از حد مجاز است {0} طول کاراکتر های")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} صحیح نمباشد")]
        public string? Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
