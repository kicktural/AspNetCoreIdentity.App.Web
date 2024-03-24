using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.App.Web.Models
{
    public class AppUser : IdentityUser
    {
        public string? City { get; set; }
        public string? Picture { get; set; }
        public DateTime? BrityDate { get; set; }
        public Gender? Gender { get; set; }
    }
}
