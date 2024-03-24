using AspNetCoreIdentity.App.Web.Extensions;
using AspNetCoreIdentity.App.Web.Models;
using AspNetCoreIdentity.App.Web.Services;
using AspNetCoreIdentity.App.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
namespace AspNetCoreIdentity.App.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                PhoneNumber =
                request.Phone,
                Email = request.Email
            }, request.PasswordConfirm);


            if (identityResult.Succeeded)
            {
                TempData["Message"] = "Kullanici kayit islemi basariyla gerceklesmisdir!";

                return Redirect("/Auth/SignUp");
                //return RedirectToAction(nameof(AuthController.SignUp));
            }


            ModelState.AddModelErrorlist(identityResult.Errors.Select(x => x.Description).ToList());

            return View();
        }




        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(model.Email);



            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya Sifre yanlis!");
                return View();
            }

            var SignInresult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RemamberMe, true);

            if (SignInresult.Succeeded)
            {
                return Redirect(returnUrl!);
            }


            if (SignInresult.IsLockedOut)
            {
                ModelState.AddModelErrorlist(new List<string>() { "3 Dakika boyunca giris yapamazsiniz." });
            }

            ModelState.AddModelErrorlist(new List<string>() { $"Email veya Sifre yanlis!", $"(Basarisiz giris sayisi = " +
                $"{await _userManager.GetAccessFailedCountAsync(hasUser)})" });

            return View();
        }


        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Bu email adresine sahib kullanici bulunamamistir!");
                return View();
            }

            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Auth", new { userId = hasUser.Id, Token = passwordResetToken },
                HttpContext.Request.Scheme);


            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            TempData["success"] = "Sifre yenileme linki E-Posta adresinize gonderilmistir";

            return RedirectToAction(nameof(ForgetPassword));
        }


        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
            {
                throw new Exception("Bir hata meydana geldi!");
            }

            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Boyle bir kullanici bulunamamistir.");
                return View();
            }


            var result = await _userManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);


            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Sifreniz basariyla yenilenmistir";
            }
            else
            {
                ModelState.AddModelErrorlist(result.Errors.Select(x =>x.Description).ToList());
            }

            return View();
        }
    }
}
