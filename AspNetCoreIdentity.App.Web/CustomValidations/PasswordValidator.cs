using AspNetCoreIdentity.App.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.App.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {

            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUserName", Description = "Sifre alani kullanici adi iceremez!" });
            }


            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordContainUserName1234", Description = "Sifre alani ardisik sayi iceremez!" });
            }


            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
           
              return Task.FromResult(IdentityResult.Success);
            
        }
    }
}
