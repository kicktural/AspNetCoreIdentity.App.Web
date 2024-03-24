using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.App.Web.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Role ismi alani bos birakilamaz!")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
