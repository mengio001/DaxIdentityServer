using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using IdentityModel;
using QuizTower.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizTower.IDP.Pages.User.Registration
{

    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly ILocalUserService _localUserService;
        //private readonly IIdentityServerInteractionService _interaction;

        public IndexModel(ILocalUserService localUserService, IIdentityServerInteractionService interaction)
        {
            _localUserService = localUserService ??
                                throw new ArgumentNullException(nameof(localUserService));
            //_interaction = interaction ??
            //               throw new ArgumentNullException(nameof(interaction));
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IActionResult OnGet(string returnUrl)
        {
            BuildModel(returnUrl);

            return Page();
        }

        private void BuildModel(string returnUrl)
        {
            Input = new InputModel
            {
                ReturnUrl = returnUrl
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                BuildModel(Input.ReturnUrl);
                return Page();
            }

            // create user & claims
            var userToCreate = new Entities.AspNetUser
            {
                UserName = Input.UserName,
                Subject = Guid.NewGuid().ToString(),
                Email = Input.Email,
                Active = false
            };

            userToCreate.Claims.Add(new Entities.AspNetUserClaim()
            {
                Type = "country",
                Value = Input.Country
            });

            userToCreate.Claims.Add(new Entities.AspNetUserClaim()
            {
                Type = JwtClaimTypes.GivenName,
                Value = Input.GivenName
            });

            userToCreate.Claims.Add(new Entities.AspNetUserClaim()
            {
                Type = JwtClaimTypes.FamilyName,
                Value = Input.FamilyName
            });

            await _localUserService.AddUserAsync(userToCreate, Input.Password);
            await _localUserService.SaveChangesAsync();

            // ActivationLink without sending email but printing into console because, we don't have e-mail/exchange server to send emails.
            var activationLink = Url.PageLink("/user/activation/index", values: new { securityCode = userToCreate.SecurityCode });

            // todo: building reactivate/resend 'SecurityCode', after 1 hour expired.
            Console.WriteLine($"activationLink: {activationLink}");
            return Redirect("~/User/ActivationCodeSent");

            /**
             * Information about login-flow...
             * We don't want to log in the user before the user has an active account
             */

            //// Issue authentication cookie (log the user in)
            //var isUser = new IdentityServerUser(userToCreate.Subject)
            //{
            //    DisplayName = userToCreate.UserName
            //};
            //await HttpContext.SignInAsync(isUser);

            //// continue with the flow     
            //if (_interaction.IsValidReturnUrl(Input.ReturnUrl)
            //    || Url.IsLocalUrl(Input.ReturnUrl))
            //{
            //    return Redirect(Input.ReturnUrl);
            //}

            //return Redirect("~/");
        }
    }
}