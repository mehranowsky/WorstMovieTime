using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage ="{0} را وارد کنید")]        
        [Length(2,30, ErrorMessage ="{0} باید بین 2 تا 30 کاراکتر باشد")]
        public string? Name { get; set; }
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Length(11, 11, ErrorMessage ="{0} صحیح نمباشد")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "{0} صحیح نمباشد")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Length(8, 20, ErrorMessage = "{0} باید بین 8 تا 20 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
