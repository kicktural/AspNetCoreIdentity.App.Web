using AspNetCoreIdentity.App.Web.CustomValidations;
using AspNetCoreIdentity.App.Web.Localizations;
using AspNetCoreIdentity.App.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.App.Web.Extensions
{
    public static class StartUpExtensions
    {

        public static void AddIdentityWithExt(this IServiceCollection services)
        {


            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true; //Login olan E-Posta ile ayni E-Posta ile Login olamaz.

                options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklmnbvcxz1234567890_QWERTYUIOPASDFGHJKLZXCVBNM"; //kullanici adi izin verilen karakterler.

                options.Password.RequiredLength = 6;

                options.Password.RequireNonAlphanumeric = false;

                options.Password.RequireLowercase = true;

                options.Password.RequireUppercase = true;

                options.Password.RequireDigit = false;

                options.Lockout.MaxFailedAccessAttempts = 3;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

            }).AddPasswordValidator<PasswordValidator>().AddDefaultTokenProviders().AddUserValidator<UserValidator>
            ().AddErrorDescriber<LocalizationIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>();


        }
    }
}
