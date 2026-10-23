// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Gharshare.CommonHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gharshare.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private IUnitofWork _unitofWork;

        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnitofWork iunitofWork
            )

        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _unitofWork = iunitofWork;

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "* The {0} field is required.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "* The {0} field is required.")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "* The {0} field is required.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            //[Required]
            [Required(ErrorMessage = "The {0} field is required.")]
            public string Name { get; set; }
            public string? SurName { get; set; }

            public string? Address { get; set; }

            public int CityID { get; set; }
            public int StateID { get; set; }

            [Display(Name = "Postalcode")]
            public string? Postalcode { get; set; }
            [Required(ErrorMessage = "* The {0} field is required.")]
            public ApplicationUser.usertype UserType { get; set; }
            [Required(ErrorMessage = "* The {0} field is required.")]
            [ValidateNever]
            public string? Mobile { get; set; }
            [Required(ErrorMessage = "* The {0} field is required.")]
            public string? CNIC { get; set; }

            [Required(ErrorMessage = "* The {0} field is required.")]
            public ApplicationUser.gender Gender { get; set; }
            public bool AgreedtoTerms { get; set; }
        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            States = _unitofWork.State.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()

                            });
            Cities = _unitofWork.City.GetAll().OrderBy(s => s.Name).ToList().Select(
                            s => new SelectListItem()
                            {
                                Text = s.Name,
                                Value = s.ID.ToString()
                            });
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            #region commented code 
            //if (!_roleManager.RoleExistsAsync(WebSiteRoles.Role_Admin).GetAwaiter().GetResult())
            //{
            //    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Admin)).GetAwaiter().GetResult();
            //    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Manager)).GetAwaiter().GetResult();
            //    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Agent)).GetAwaiter().GetResult();
            //    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Landlord)).GetAwaiter().GetResult();
            //    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Tenant)).GetAwaiter().GetResult();            //}
            #endregion

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                //await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                MailAddress address = new MailAddress(Input.Email);
                string userName = address.User;
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.UserName = userName;
                user.Name = Input.Name;
                user.Address = Input.Address;
                user.CityID = Input.CityID;
               // user.StateID = Input.StateID;
                user.PostalCode = Input.Postalcode;
                user.UserType = Input.UserType;
                //user.UserType = ApplicationUser.usertype.landlord;
                user.Mobile = Input.Mobile;
                user.CNIC = Input.CNIC;
                user.Gender = Input.Gender;
                user.AgreedtoTerms = Input.AgreedtoTerms;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                     
                    if (user.UserType ==ApplicationUser.usertype.landlord)
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Landlord).GetAwaiter().GetResult();
                    else if (user.UserType == ApplicationUser.usertype.tenant)
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Tenant).GetAwaiter().GetResult();

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/account/confirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
