using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using ClinicHistoryApi.Auth.Models;
using ClinicHistoryApi.Auth.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ClinicHistoryApi.Auth;


namespace ClinicHistoryApi.Controllers
{
	[SecurityHeaders]
	public class AccountController : Controller
	{
		private readonly IIdentityServerInteractionService _interaction;
		private readonly IEventService _events;
		private readonly AccountService _account;		
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(
			IIdentityServerInteractionService interaction,
			IClientStore clientStore,
			IHttpContextAccessor httpContextAccessor,
			IEventService events,
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			IAuthenticationSchemeProvider schemeProvider
			)
		{
			_interaction = interaction;
			_account = new AccountService(interaction, httpContextAccessor, schemeProvider, clientStore);			
			_userManager = userManager;
			_signInManager = signInManager;
			_events = events;
		}

		/// <summary>
		/// Show login page
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> Login(string returnUrl)
		{
			var vm = await _account.BuildLoginViewModelAsync(returnUrl);			
			return View(vm);
		}

		/// <summary>
		/// Handle postback from username/password login
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginInputModel model)
		{
			if (ModelState.IsValid)
			{
				var ctx = _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

				var user = _userManager.FindByNameAsync(model.Username).Result;				

				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, false);
				if (result.Succeeded)
				{
					await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));

					AuthenticationProperties props = null;

					if (AccountOptions.AllowRememberLogin && model.RememberLogin)
					{
						props = new AuthenticationProperties
						{
							IsPersistent = true,
							ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
						};
					}

					await HttpContext.SignInAsync(user.Id, user.UserName, props);

					if (_interaction.IsValidReturnUrl(model.ReturnUrl))
					{
						return Redirect(model.ReturnUrl);
					}
					return Redirect("~/");
				}
				await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));
				ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
			}

			// something went wrong, show form with error
			var vm = await _account.BuildLoginViewModelAsync(model);
			return View(vm);
		}


		/// <summary>
		/// Show logout page
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> Logout(string logoutId)
		{
			var vm = await _account.BuildLoggedOutViewModelAsync(logoutId);
			var user = HttpContext.User;
			if (user?.Identity.IsAuthenticated == true)
			{
				// delete local authentication cookie
				await HttpContext.SignOutAsync();

				// raise the logout event
				await _events.RaiseAsync(new UserLogoutSuccessEvent(user.GetSubjectId(), user.GetDisplayName()));
			}
			return Redirect(vm.PostLogoutRedirectUri);

			//var vm = await _account.BuildLogoutViewModelAsync(logoutId);
			//if (vm.ShowLogoutPrompt == false)
			//{
			//	return await Logout(vm);
			//}

			//return View(vm);
		}

		/// <summary>
		/// Handle logout page postback
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout(LogoutInputModel model)
		{
			// build a model so the logged out page knows what to display
			var vm = await _account.BuildLoggedOutViewModelAsync(model.LogoutId);

			var user = HttpContext.User;
			if (user?.Identity.IsAuthenticated == true)
			{
				// delete local authentication cookie
				await HttpContext.SignOutAsync();

				// raise the logout event
				await _events.RaiseAsync(new UserLogoutSuccessEvent(user.GetSubjectId(), user.GetDisplayName()));
			}

			// check if we need to trigger sign-out at an upstream identity provider
			if (vm.TriggerExternalSignout)
			{
				// build a return URL so the upstream provider will redirect back
				// to us after the user has logged out. this allows us to then
				// complete our single sign-out processing.
				string url = Url.Action("Logout", new { logoutId = vm.LogoutId });

				// this triggers a redirect to the external provider for sign-out
				return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
			}

			LogLogoutSuccess();

			return View("LoggedOut", vm);
		}

		private void LogLogoutSuccess()
		{
			var subjectId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

			var name = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
		}
	}
}