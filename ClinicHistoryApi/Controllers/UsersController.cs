using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClinicHistoryApi.Data;
using ClinicHistoryApi.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;


namespace ClinicHistoryApi.Controllers
{
	[AllowAnonymous]
	[Produces("application/json")]
	public class UsersController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly UserStore<IdentityUser> _userStore;
		private readonly UsersDbContext _dbContext;

		public UsersController(UserManager<IdentityUser> userManager, UsersDbContext dbContext)
		{
			_userManager = userManager;
			_dbContext = dbContext;
			//this should be injected
			_userStore = new UserStore<IdentityUser>(_dbContext);
		}

		[HttpPost("api/users")]
		public async Task<IdentityResult> Register([FromBody] RegisterModel model)
		{
			var user = await _userStore.FindByNameAsync(model.Email);
			if (user == null)
			{
				user = new IdentityUser { UserName = model.Email, Email = model.Email };
				return await _userManager.CreateAsync(user, model.Password);
			}
			else
			{
				await _userManager.RemovePasswordAsync(user);
				return await  _userManager.AddPasswordAsync(user, model.Password);				
			}
		}
	}
}