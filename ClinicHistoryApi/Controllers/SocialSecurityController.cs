using System.Linq;
using System.Threading.Tasks;
using ClinicHistoryApi.Entities;
using ClinicHistoryApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryApi.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer", Policy = "patients")]
	[Produces("application/json")]	
	public class SocialSecurityController : Controller
    {
		private readonly IGenericService _genericService;
		
		public SocialSecurityController(IGenericService genericService)
        {
			_genericService = genericService;		}
		
		[HttpGet("api/social-securities/")]		
		public async Task<SocialSecurity[]> Get(string filter)
		{			
			// TODO: Add filter by name

			var result = _genericService.Find<SocialSecurity>(
				x => string.IsNullOrEmpty(filter) || x.Name.Contains(filter),					
				y => y.OrderBy(z => z.Name));
			return await result;
		}
	}
}