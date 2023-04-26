// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable



using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Prototype.Controllers;



namespace Prototype.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _sender;
        private MailHelper emailHelper;
        private static Random random = new Random();



        public RegisterConfirmationModel(UserManager<IdentityUser> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
            emailHelper = new MailHelper();
        }



        /// <summary>
                ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
                ///     directly from your code. This API may change or be removed in future releases.
                /// </summary>
        public string Email { get; set; }



        /// <summary>
                ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
                ///     directly from your code. This API may change or be removed in future releases.
                /// </summary>
        public bool DisplayConfirmAccountLink { get; set; }



        /// <summary>
                ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
                ///     directly from your code. This API may change or be removed in future releases.
                /// </summary>
        public string EmailConfirmationUrl { get; set; }
        public string ConfirmEmail { get; set; }

   
        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
            returnUrl = returnUrl ?? Url.Content("~/ConfirmEmail");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }
            Email = email;

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            EmailConfirmationUrl = Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new { area = "Identity", userId = userId, code = code },
            protocol: Request.Scheme);

            bool responseEmail = emailHelper.SendEmail(email, EmailConfirmationUrl);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newRefreshToken = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
                       
            await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken);


            if (responseEmail)
            {
              
              

                return Page();
            }

            return null;

        }
    }
}


