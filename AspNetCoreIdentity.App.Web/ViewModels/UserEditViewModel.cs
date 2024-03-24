using AspNetCoreIdentity.App.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.ViewModels
{
    public class UserEditViewModel
    {

        [Required(ErrorMessage = "Kullanici Ad alani bos birakilamaz!")]
        [Display(Name = "Kullanıcı adı :")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Kullanici Email alani bos birakilamaz!")]
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formati yalnistir!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Kullanici Phone alani bos birakilamaz!")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; } = null!;

        [Display(Name = "Dogum tarihi :")]
        [DataType(DataType.Date)]
        public DateTime? BrithDate { get; set; }

        [Display(Name = "Sehir :")]
        public string? City { get; set; }

        [Display(Name = "Profil resmi :")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Cinsiyet :")]
        public Gender? Gender { get; set; }

    }
}
