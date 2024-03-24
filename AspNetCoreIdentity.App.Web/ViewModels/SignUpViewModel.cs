using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class SignUpViewModel
    {

        public SignUpViewModel() { }
        public SignUpViewModel(string userName, string email, string phone, string password, string passwordConfirm)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }


        [Required(ErrorMessage = "Kullanici Ad alani bos birakilamaz!")]
        [Display(Name = "Kullanıcı adı :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanici Email alani bos birakilamaz!")]
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formati yalnistir!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanici Phone alani bos birakilamaz!")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kullanici Sifre alani bos birakilamaz!")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Kullanici Tekrar Sifre alani bos birakilamaz!")]
        [Display(Name = "Şifre Tekrar :")]
        [Compare("Password", ErrorMessage ="Tekrar ayni deyildir!")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string PasswordConfirm { get; set; }
    }
}
