using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

namespace ClinicHistoryApi.Auth.Services
{
	public class ProfileService : IProfileService
	{
		public Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			context.IssuedClaims.AddRange(context.Subject.Claims);
			return Task.CompletedTask;
		}

		public Task IsActiveAsync(IsActiveContext context)
		{
			context.IsActive = true;
			return Task.CompletedTask;
		}
	}
}
