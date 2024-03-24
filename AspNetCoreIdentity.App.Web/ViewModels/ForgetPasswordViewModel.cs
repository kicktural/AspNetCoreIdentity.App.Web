using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Kullanici Email alani bos birakilamaz!")]
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formati yalnistir!")]
        public string Email { get; set; }
    }
}
