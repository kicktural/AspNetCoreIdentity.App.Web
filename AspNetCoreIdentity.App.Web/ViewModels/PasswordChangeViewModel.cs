using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Eski Kullanici Sifre alani bos birakilamaz!")]
        [Display(Name = "Eski Şifre giriniz :")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string PasswordOld { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni Kullanici Sifre alani bos birakilamaz!")]
        [Display(Name = "Yeni Şifre :")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string PasswordNew { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni Kullanici Tekrar Sifre alani bos birakilamaz!")]
        [Display(Name = "Yeni Şifre Tekrar :")]
        [Compare(nameof(PasswordNew), ErrorMessage = "Sifre ayni deyildir!")]
        [MinLength(6, ErrorMessage = "Sifreniz en az 6 karakter ola bilir.")]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
