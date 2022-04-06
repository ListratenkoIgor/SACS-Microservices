using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Interfaces;

namespace AuthorizationService.Implementations
{
    public class AuthorizationServiceImpl: Interfaces.IAuthorizationService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly IEmailSender _emailSender;
        public AuthorizationServiceImpl(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager/*,
            IEmailSender emailSender
            */)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
        }

        public void Login(string Email, string Password, bool RememberMe=true) {
            var result = _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
            result.Wait();
            if (result.Result.Succeeded)
            {
               // _logger.LogInformation("User logged in.");
            }
            else
            {
                //Error
            }
            return ; 
        }
        public void Register(string Email, string Password) {
            var user = new IdentityUser { UserName = Email, Email = Email };
            var result = _userManager.CreateAsync(user, Password);
            result.Wait();
            if (result.Result.Succeeded)
            {
                _signInManager.SignInAsync(user, isPersistent: false).Wait();
                //_logger.LogInformation("User created a new account with password.");

                /* Email Confirmation
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                */
            }
            return ; 
        }
    }
}
