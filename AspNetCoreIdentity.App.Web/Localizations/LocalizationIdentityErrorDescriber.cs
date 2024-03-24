using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AspNetCoreIdentity.App.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {

        public override IdentityError DuplicateUserName(string userName)
        {

            return new()
            {
                Code = "DuplicateUserName",
                Description =
                $" {userName} daha once baska bir kullanici tarafindan alinmisdir! "
            };


            //return base.DuplicateUserName(userName);
        }



        public override IdentityError DuplicateEmail(string email)
        {


            return new()
            {
                Code = "DuplicateEmail",
                Description =
                $"{email} daha once baska bir kullanici tarafindan alinmisdir! "
            };

        }


        public override IdentityError PasswordTooShort(int length)
        {

            return new()
            {
                Code = "PasswordTooShort",
                Description =
              $"Sifre en az 6 karakterli olmalidir!"
            };
        }
    }
}
