using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage ="{0} را وارد کنید")]        
        [Length(2,30, ErrorMessage ="{0} باید بین 2 تا 30 کاراکتر باشد")]
        public string? Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "بیش از حد مجاز است {0} طول کاراکتر های")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} صحیح نمباشد")]
        public string? Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Length(8, 20, ErrorMessage = "{0} باید بین 8 تا 20 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name ="تکرار رمز عبور")]
        [Required(ErrorMessage ="{0} خالی است")]
        [Compare(nameof(Password), ErrorMessage ="{0} یکسان نمیباشد")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
