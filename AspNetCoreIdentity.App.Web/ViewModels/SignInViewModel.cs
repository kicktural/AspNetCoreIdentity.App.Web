using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class SignInViewModel
    {


        public SignInViewModel() { }
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "Kullanici Email alani bos birakilamaz!")]
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formati yalnistir!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kullanici Sifre alani bos birakilamaz!")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string Password { get; set; }

        public bool RemamberMe { get; set; }
    }
}
