using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class ResetPasswordViewModel
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kullanici Sifre alani bos birakilamaz!")]
        [Display(Name = "Yeni Şifre :")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kullanici Tekrar Sifre alani bos birakilamaz!")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
